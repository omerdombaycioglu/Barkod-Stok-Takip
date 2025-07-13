-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 13 Tem 2025, 20:48:56
-- Sunucu sürümü: 10.4.32-MariaDB
-- PHP Sürümü: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `stok_takip_otomasyonu`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `depo_konum`
--

CREATE TABLE `depo_konum` (
  `id` int(11) NOT NULL,
  `kat` varchar(50) NOT NULL,
  `konum` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `islem_turu`
--

CREATE TABLE `islem_turu` (
  `islem_turu_id` tinyint(4) NOT NULL,
  `tanim` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `islem_turu`
--

INSERT INTO `islem_turu` (`islem_turu_id`, `tanim`) VALUES
(0, 'Stok'),
(1, 'Proje'),
(2, 'Hurda/İade');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanicilar`
--

CREATE TABLE `kullanicilar` (
  `kullanici_id` int(11) NOT NULL,
  `kullanici_adi` varchar(50) NOT NULL,
  `sifre` varchar(255) NOT NULL,
  `kullanici_yetki` tinyint(4) NOT NULL CHECK (`kullanici_yetki` in (1,2)),
  `ad_soyad` varchar(100) DEFAULT NULL,
  `aktif` tinyint(1) DEFAULT 1,
  `kayit_tarihi` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `kullanicilar`
--

INSERT INTO `kullanicilar` (`kullanici_id`, `kullanici_adi`, `sifre`, `kullanici_yetki`, `ad_soyad`, `aktif`, `kayit_tarihi`) VALUES
(1, 'admin', 'admin', 1, 'Sistem Yöneticisi', 1, '2025-07-04 13:59:18'),
(2, 'kullanici', '123', 2, 'Standart Kullanıcı', 1, '2025-07-04 13:59:18');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `projeler`
--

CREATE TABLE `projeler` (
  `proje_id` int(11) NOT NULL,
  `proje_kodu` varchar(50) NOT NULL,
  `proje_tanimi` varchar(255) NOT NULL,
  `aktif` tinyint(1) DEFAULT 1,
  `kayit_tarihi` datetime DEFAULT current_timestamp(),
  `olusturan_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `projeler`
--

INSERT INTO `projeler` (`proje_id`, `proje_kodu`, `proje_tanimi`, `aktif`, `kayit_tarihi`, `olusturan_id`) VALUES
(39, 'E666', 'E666 VANA OTOMASYONU', 0, '2025-07-13 01:44:19', 1),
(42, 'E666', 'E666 VANA OTOMASYONU', 1, '2025-07-13 21:47:49', 1);

--
-- Tetikleyiciler `projeler`
--
DELIMITER $$
CREATE TRIGGER `trg_projeler_before_insert` BEFORE INSERT ON `projeler` FOR EACH ROW BEGIN
  IF NEW.aktif = 1 THEN
    IF EXISTS (
      SELECT 1 FROM projeler
      WHERE proje_kodu = NEW.proje_kodu AND aktif = 1
    ) THEN
      SIGNAL SQLSTATE '45000'
      SET MESSAGE_TEXT = 'Aynı proje_kodu ile aktif başka bir proje zaten mevcut.';
    END IF;
  END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trg_projeler_before_update` BEFORE UPDATE ON `projeler` FOR EACH ROW BEGIN
  IF NEW.aktif = 1 AND (OLD.aktif <> NEW.aktif OR OLD.proje_kodu <> NEW.proje_kodu) THEN
    IF EXISTS (
      SELECT 1 FROM projeler
      WHERE proje_kodu = NEW.proje_kodu AND aktif = 1 AND proje_id <> OLD.proje_id
    ) THEN
      SIGNAL SQLSTATE '45000'
      SET MESSAGE_TEXT = 'Aynı proje_kodu ile aktif başka bir proje zaten mevcut.';
    END IF;
  END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `proje_hareketleri`
--

CREATE TABLE `proje_hareketleri` (
  `id` int(11) NOT NULL,
  `proje_id` int(11) NOT NULL,
  `urun_id` int(11) NOT NULL,
  `miktar` int(11) NOT NULL,
  `kullanici_id` int(11) NOT NULL,
  `islem_tarihi` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `proje_hareketleri`
--

INSERT INTO `proje_hareketleri` (`id`, `proje_id`, `urun_id`, `miktar`, `kullanici_id`, `islem_tarihi`) VALUES
(20, 39, 260, 1, 1, '2025-07-13 01:44:56'),
(21, 39, 286, 1, 1, '2025-07-13 15:50:54');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `proje_urunleri`
--

CREATE TABLE `proje_urunleri` (
  `id` int(11) NOT NULL,
  `proje_id` int(11) NOT NULL,
  `urun_id` int(11) NOT NULL,
  `miktar` int(11) NOT NULL,
  `log_date` datetime DEFAULT current_timestamp(),
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `proje_urunleri`
--

INSERT INTO `proje_urunleri` (`id`, `proje_id`, `urun_id`, `miktar`, `log_date`, `user_id`) VALUES
(1205, 39, 259, 1, '2025-07-13 01:44:19', 1),
(1206, 39, 260, 1, '2025-07-13 01:44:19', 1),
(1207, 39, 261, 14, '2025-07-13 01:44:19', 1),
(1208, 39, 262, 1, '2025-07-13 01:44:19', 1),
(1209, 39, 263, 2, '2025-07-13 01:44:19', 1),
(1210, 39, 264, 3, '2025-07-13 01:44:19', 1),
(1211, 39, 265, 1, '2025-07-13 01:44:19', 1),
(1212, 39, 266, 1, '2025-07-13 01:44:19', 1),
(1213, 39, 267, 2, '2025-07-13 01:44:19', 1),
(1214, 39, 268, 1, '2025-07-13 01:44:19', 1),
(1215, 39, 269, 1, '2025-07-13 01:44:19', 1),
(1216, 39, 270, 12, '2025-07-13 01:44:19', 1),
(1217, 39, 271, 73, '2025-07-13 01:44:19', 1),
(1218, 39, 272, 10, '2025-07-13 01:44:19', 1),
(1219, 39, 273, 5, '2025-07-13 01:44:19', 1),
(1220, 39, 274, 39, '2025-07-13 01:44:19', 1),
(1221, 39, 275, 146, '2025-07-13 01:44:19', 1),
(1222, 39, 276, 1, '2025-07-13 01:44:19', 1),
(1223, 39, 277, 1, '2025-07-13 01:44:19', 1),
(1224, 39, 278, 1, '2025-07-13 01:44:19', 1),
(1225, 39, 279, 23, '2025-07-13 01:44:19', 1),
(1226, 39, 280, 22, '2025-07-13 01:44:19', 1),
(1227, 39, 281, 4, '2025-07-13 01:44:19', 1),
(1228, 39, 282, 1, '2025-07-13 01:44:19', 1),
(1229, 39, 283, 1, '2025-07-13 01:44:19', 1),
(1230, 39, 284, 6, '2025-07-13 01:44:19', 1),
(1231, 39, 285, 9, '2025-07-13 01:44:19', 1),
(1232, 39, 286, 28, '2025-07-13 01:44:19', 1),
(1233, 39, 287, 2, '2025-07-13 01:44:19', 1),
(1234, 39, 288, 22, '2025-07-13 01:44:19', 1),
(1235, 39, 289, 2, '2025-07-13 01:44:19', 1),
(1236, 39, 290, 12, '2025-07-13 01:44:19', 1),
(1237, 39, 291, 45, '2025-07-13 01:44:19', 1),
(1238, 39, 292, 1, '2025-07-13 01:44:19', 1),
(1239, 39, 293, 95, '2025-07-13 01:44:19', 1),
(1240, 39, 294, 1, '2025-07-13 01:44:19', 1),
(1241, 39, 295, 1, '2025-07-13 01:44:19', 1),
(1242, 39, 296, 1, '2025-07-13 01:44:19', 1),
(1243, 39, 297, 1, '2025-07-13 01:44:19', 1),
(1244, 39, 298, 1, '2025-07-13 01:44:19', 1),
(1245, 39, 299, 5, '2025-07-13 01:44:19', 1),
(1246, 39, 300, 3, '2025-07-13 01:44:19', 1),
(1247, 39, 301, 7, '2025-07-13 01:44:19', 1),
(1248, 39, 302, 1, '2025-07-13 01:44:19', 1),
(1249, 39, 303, 2, '2025-07-13 01:44:19', 1),
(1250, 39, 304, 2, '2025-07-13 01:44:19', 1),
(1251, 39, 305, 2, '2025-07-13 01:44:19', 1),
(1252, 39, 306, 1, '2025-07-13 01:44:19', 1),
(1253, 39, 307, 1, '2025-07-13 01:44:19', 1),
(1254, 39, 308, 1, '2025-07-13 01:44:19', 1),
(1255, 39, 309, 2, '2025-07-13 01:44:19', 1),
(1256, 39, 310, 1, '2025-07-13 01:44:19', 1),
(1257, 39, 311, 1, '2025-07-13 01:44:19', 1),
(1258, 39, 312, 1, '2025-07-13 01:44:19', 1),
(1259, 39, 313, 1, '2025-07-13 01:44:19', 1),
(1260, 39, 314, 35, '2025-07-13 01:44:19', 1),
(1261, 39, 315, 4, '2025-07-13 01:44:19', 1),
(1262, 39, 316, 1, '2025-07-13 01:44:19', 1),
(1263, 39, 317, 1, '2025-07-13 01:44:19', 1),
(1264, 39, 318, 1, '2025-07-13 01:44:19', 1),
(1265, 39, 319, 4, '2025-07-13 01:44:19', 1),
(1266, 39, 320, 1, '2025-07-13 01:44:19', 1),
(1267, 39, 321, 3, '2025-07-13 01:44:19', 1),
(1268, 39, 322, 1, '2025-07-13 01:44:19', 1),
(1269, 39, 323, 1, '2025-07-13 01:44:19', 1),
(1270, 39, 324, 5, '2025-07-13 01:44:19', 1),
(1271, 39, 325, 5, '2025-07-13 01:44:19', 1),
(1272, 39, 326, 2, '2025-07-13 01:44:19', 1),
(1273, 39, 327, 1, '2025-07-13 01:44:19', 1),
(1274, 39, 328, 1, '2025-07-13 01:44:19', 1),
(1275, 39, 329, 6, '2025-07-13 01:44:19', 1),
(1276, 39, 330, 5, '2025-07-13 01:44:19', 1),
(1277, 39, 331, 1, '2025-07-13 01:44:19', 1),
(1278, 42, 259, 1, '2025-07-13 21:47:49', 1),
(1279, 42, 260, 1, '2025-07-13 21:47:49', 1),
(1280, 42, 261, 14, '2025-07-13 21:47:49', 1),
(1281, 42, 262, 1, '2025-07-13 21:47:49', 1),
(1282, 42, 263, 2, '2025-07-13 21:47:49', 1),
(1283, 42, 264, 3, '2025-07-13 21:47:49', 1),
(1284, 42, 265, 1, '2025-07-13 21:47:49', 1),
(1285, 42, 266, 1, '2025-07-13 21:47:49', 1),
(1286, 42, 267, 2, '2025-07-13 21:47:49', 1),
(1287, 42, 268, 1, '2025-07-13 21:47:49', 1),
(1288, 42, 269, 1, '2025-07-13 21:47:49', 1),
(1289, 42, 270, 12, '2025-07-13 21:47:49', 1),
(1290, 42, 271, 73, '2025-07-13 21:47:49', 1),
(1291, 42, 272, 10, '2025-07-13 21:47:49', 1),
(1292, 42, 273, 5, '2025-07-13 21:47:49', 1),
(1293, 42, 274, 39, '2025-07-13 21:47:49', 1),
(1294, 42, 275, 146, '2025-07-13 21:47:49', 1),
(1295, 42, 276, 1, '2025-07-13 21:47:49', 1),
(1296, 42, 277, 1, '2025-07-13 21:47:49', 1),
(1297, 42, 278, 1, '2025-07-13 21:47:49', 1),
(1298, 42, 279, 23, '2025-07-13 21:47:49', 1),
(1299, 42, 280, 22, '2025-07-13 21:47:49', 1),
(1300, 42, 281, 4, '2025-07-13 21:47:49', 1),
(1301, 42, 282, 1, '2025-07-13 21:47:49', 1),
(1302, 42, 283, 1, '2025-07-13 21:47:49', 1),
(1303, 42, 284, 6, '2025-07-13 21:47:49', 1),
(1304, 42, 285, 9, '2025-07-13 21:47:49', 1),
(1305, 42, 286, 28, '2025-07-13 21:47:49', 1),
(1306, 42, 287, 2, '2025-07-13 21:47:49', 1),
(1307, 42, 288, 22, '2025-07-13 21:47:49', 1),
(1308, 42, 289, 2, '2025-07-13 21:47:49', 1),
(1309, 42, 290, 12, '2025-07-13 21:47:49', 1),
(1310, 42, 291, 45, '2025-07-13 21:47:49', 1),
(1311, 42, 292, 1, '2025-07-13 21:47:50', 1),
(1312, 42, 293, 95, '2025-07-13 21:47:50', 1),
(1313, 42, 294, 1, '2025-07-13 21:47:50', 1),
(1314, 42, 295, 1, '2025-07-13 21:47:50', 1),
(1315, 42, 296, 1, '2025-07-13 21:47:50', 1),
(1316, 42, 297, 1, '2025-07-13 21:47:50', 1),
(1317, 42, 298, 1, '2025-07-13 21:47:50', 1),
(1318, 42, 299, 5, '2025-07-13 21:47:50', 1),
(1319, 42, 300, 3, '2025-07-13 21:47:50', 1),
(1320, 42, 301, 7, '2025-07-13 21:47:50', 1),
(1321, 42, 302, 1, '2025-07-13 21:47:50', 1),
(1322, 42, 303, 2, '2025-07-13 21:47:50', 1),
(1323, 42, 304, 2, '2025-07-13 21:47:50', 1),
(1324, 42, 305, 2, '2025-07-13 21:47:50', 1),
(1325, 42, 306, 1, '2025-07-13 21:47:50', 1),
(1326, 42, 307, 1, '2025-07-13 21:47:50', 1),
(1327, 42, 308, 1, '2025-07-13 21:47:50', 1),
(1328, 42, 309, 2, '2025-07-13 21:47:50', 1),
(1329, 42, 310, 1, '2025-07-13 21:47:50', 1),
(1330, 42, 311, 1, '2025-07-13 21:47:50', 1),
(1331, 42, 312, 1, '2025-07-13 21:47:50', 1),
(1332, 42, 313, 1, '2025-07-13 21:47:50', 1),
(1333, 42, 314, 35, '2025-07-13 21:47:50', 1),
(1334, 42, 315, 4, '2025-07-13 21:47:50', 1),
(1335, 42, 316, 1, '2025-07-13 21:47:50', 1),
(1336, 42, 317, 1, '2025-07-13 21:47:50', 1),
(1337, 42, 318, 1, '2025-07-13 21:47:50', 1),
(1338, 42, 319, 4, '2025-07-13 21:47:50', 1),
(1339, 42, 320, 1, '2025-07-13 21:47:50', 1),
(1340, 42, 321, 3, '2025-07-13 21:47:50', 1),
(1341, 42, 322, 1, '2025-07-13 21:47:50', 1),
(1342, 42, 323, 1, '2025-07-13 21:47:50', 1),
(1343, 42, 324, 5, '2025-07-13 21:47:50', 1),
(1344, 42, 325, 5, '2025-07-13 21:47:50', 1),
(1345, 42, 326, 2, '2025-07-13 21:47:50', 1),
(1346, 42, 327, 1, '2025-07-13 21:47:50', 1),
(1347, 42, 328, 1, '2025-07-13 21:47:50', 1),
(1348, 42, 329, 6, '2025-07-13 21:47:50', 1),
(1349, 42, 330, 5, '2025-07-13 21:47:50', 1),
(1350, 42, 331, 1, '2025-07-13 21:47:50', 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urunler`
--

CREATE TABLE `urunler` (
  `urun_id` int(11) NOT NULL,
  `urun_adi` varchar(100) NOT NULL,
  `urun_kodu` varchar(50) DEFAULT NULL,
  `aciklama` text DEFAULT NULL,
  `urun_barkod` varchar(50) DEFAULT NULL,
  `urun_marka` varchar(50) DEFAULT NULL,
  `urun_no` varchar(50) DEFAULT NULL,
  `miktar` int(11) NOT NULL DEFAULT 0,
  `kritik_seviye` int(11) DEFAULT NULL,
  `kayit_tarihi` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `urunler`
--

INSERT INTO `urunler` (`urun_id`, `urun_adi`, `urun_kodu`, `aciklama`, `urun_barkod`, `urun_marka`, `urun_no`, `miktar`, `kritik_seviye`, `kayit_tarihi`) VALUES
(256, 'Klemens', '', NULL, '232', 'LEU', NULL, 69, NULL, '2025-07-11 14:26:57'),
(259, '4 Gerilim girişi/Akım girişi', 'AS04AD-A', NULL, '777', 'DEL', NULL, 3, NULL, '2025-07-11 16:38:58'),
(260, 'AS200 PLC - 16DI / 12DO PNP, Dahili Ethernet / CAN', 'AS228P-A', NULL, '222', 'DEL', NULL, 0, NULL, '2025-07-11 16:38:58'),
(261, 'AS16AP11P-A ,8D/8P Plc Ek Dijital Modül', 'AS16AP11P-A', NULL, '888', 'DEL', NULL, 1, NULL, '2025-07-11 16:38:58'),
(262, 'Endüstriyel Ethernet DIACloud Bulut Yönlendiriciler', 'DX-2300LN-WW', NULL, NULL, 'DEL', NULL, 0, NULL, '2025-07-11 16:38:58'),
(263, 'A2 Servo Sürücü - 1000W', 'ASD-A2-1021-M', NULL, '0', 'DEL', NULL, 1, NULL, '2025-07-11 16:38:58'),
(264, 'A2 Servo Sürücü - 400 Watt', 'ASD-A2-0421-M', NULL, NULL, 'DEL', NULL, 0, NULL, '2025-07-11 16:38:58'),
(265, 'Pano Soğutma Termostat\'ı 0-70°C Ray Tipi - Emas 10A 230V AC', 'PTM111', NULL, NULL, 'EMAS', NULL, 0, NULL, '2025-07-11 16:38:58'),
(266, 'Pimli Plastik Kapı Switch - NC contact type', 'BS1010', NULL, NULL, 'EMAS', NULL, 0, NULL, '2025-07-11 16:38:58'),
(267, 'Vibrasyon Kontrol Cihazı', 'EPAC3-W-F', NULL, NULL, 'ENDA', NULL, 0, NULL, '2025-07-11 16:38:58'),
(268, 'Faz yokluğu, Faz sırası hatası, 1 N/O kontak DIN1 Ray Montaj', 'MKS-03', NULL, NULL, 'ENTES', NULL, 0, NULL, '2025-07-11 16:38:58'),
(269, 'HMI 10” TFT, 1024x600, Dirençli dokunmatik, 4 GB Flash bellek, 1x Ethernet, JMobile çalışma zamanı', 'ESMA10U301', NULL, '346', 'EXOR', NULL, 1, NULL, '2025-07-11 16:38:58'),
(270, 'Transistör Çıkış Kartı 8\'li', 'GT8-V11', NULL, NULL, 'GEM', NULL, 0, NULL, '2025-07-11 16:38:58'),
(271, 'Bağlantı kablosu', '50130832', NULL, NULL, 'LEU', NULL, 0, NULL, '2025-07-11 16:38:58'),
(272, 'Bağlantı kablosu', '50130690', NULL, NULL, 'LEU', NULL, 0, NULL, '2025-07-11 16:38:58'),
(273, 'EXACT12, 8XM12, 5-KUTUPLU, KAPAK, FIŞ. VİDA TERM.', '8000-88550-0000000', NULL, NULL, 'MURR', NULL, 0, NULL, '2025-07-11 16:38:58'),
(274, 'Sensör aktüatör adaptörü', '7000-41201-0000000', NULL, NULL, 'MURR', NULL, 0, NULL, '2025-07-11 16:38:58'),
(275, 'Dairesel konektör (saha montajı için)', '7000-08601-0000000', NULL, NULL, 'MURR', NULL, 0, NULL, '2025-07-11 16:38:58'),
(276, 'Güç kaynağı 24V 10A 240W 24~28 V', 'NDR-240-24', NULL, NULL, 'MW', NULL, 0, NULL, '2025-07-11 16:38:58'),
(277, 'Tek katlı tepe lambası + Buzzer', 'SNT-7024-SB1', NULL, NULL, 'Mucco', NULL, 0, NULL, '2025-07-11 16:38:58'),
(278, 'İki elli şalt cihazı', '774350', NULL, NULL, 'PILZ', NULL, 0, NULL, '2025-07-11 16:38:58'),
(279, 'Terminal bloğu için uç braketi', '3022276', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(280, 'Klemens dizisi etiket taşıyıcı', '0811969', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(281, 'Geçişli terminal bloğu', '3211757', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(282, 'Topraklama modüler terminal bloğu', '3211766', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(283, 'Terminal bloğu için uç ve bölme plakası', '3030420', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(284, 'Topraklama modüler terminal bloğu', '3209536', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(285, 'Terminal bloğu için uç ve bölme plakası', '3030417', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(286, 'Geçişli terminal bloğu', '3209523', NULL, '987', 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(287, 'Geçmeli köprü', '3030174', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(288, 'Geçişli terminal bloğu', '3209512', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(289, 'Geçmeli köprü', '3030161', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(290, 'Sigortalı modüler klemens', '3036547', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(291, 'Geçişli terminal bloğu', '3209510', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(292, 'Röle Modülü', '2900299', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(293, 'Çift seviyeli terminal bloğu', '3210567', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(294, 'FANLI FILTRE 108 m3/h 162X162X65mm', 'FULL1500', NULL, NULL, 'QUICK', NULL, 0, NULL, '2025-07-11 16:38:58'),
(295, 'Panel Filtre (162x162x24mm) KESİM=125x125', 'FIL1500', NULL, NULL, 'QUICK', NULL, 0, NULL, '2025-07-11 16:38:58'),
(296, 'Minyatür devre kesici iC60N, 3P, 16A, C', 'A9F74316', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(297, 'TeSys Vario - kapı üzerinde acil durdurma şalteri ayırıcısı', 'VCF01', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(298, 'Minyatür devre kesici iC60N, 3P, 2A, C', 'A9F74302', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(299, 'Minyatür devre kesici iC60N, 1P, 4A, C', 'A9F74104', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(300, 'Beyaz komple pilot lambası Ø22 entegre LED\'li düz lens 230...240V', 'XB4BVM1', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(301, 'Minyatür devre kesici iC60N, 1P, 10A, C', 'A9F74110', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(302, 'TeSys K kontaktör - 3P(3 NA) - AC-3 - <= 440 V 6 A - 24 V DC bobin', 'LP1K0610BD', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(303, 'Kırmızı Ø40 Acil durdurma, kapatma Ø22 mandallı dönüş serbest bırakma 1NK 600VAC', 'XB4BS8442', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(304, 'Siyah Ø40 mantar Buton Ø22 yaylı dönüş 1NA', 'XB4BC21', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(305, 'Harmony XB5 1NK kontağı', 'ZBE102', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(306, 'Kontaktör TeSys LC1-D - 3P - AC-3 440V 9 A, Bobin 24 V DC', 'LC1D09BD', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(307, 'Termik Manyetik Motorlu Devre Kesici TeSys GV2ME - 3P - 1...1.6 A', 'GV2ME06', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(308, 'TeSys GVAE11 - yardımcı kontak - 1 NA + 1 NK', 'GVAE11', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(309, 'Minyatür devre kesici iC60N, 1P, 16A, C', 'A9F74116', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(310, 'Siyah seçim anahtarı Ø22 2 konumlu sabit 1NA 600V', 'XB4BD21', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(311, 'Yeşil sıva altı komple ışıklı buton Ø22 yaylı dönüş 1NA+1NK 24V', 'XB4BW33B5', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(312, 'Kırmızı gömme komple buton Ø22 yay geri dönüşlü 1NC \"işaretsiz\"', 'XB4BA42', NULL, NULL, 'SE', NULL, 0, NULL, '2025-07-11 16:38:58'),
(313, 'Manifold', 'SS5Y3-10L13-09B', NULL, NULL, 'SMC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(314, 'SY3000, 5 Portlu Solenoid Valf, Tüm Tipler - Yeni Stil', 'SY3200-5U1', NULL, NULL, 'SMC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(315, 'KÖRLEME PLAKASI TAKIMI', 'SY30M-26-1A', NULL, NULL, 'SMC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(316, 'Manifold', 'SS5Y3-10L13-08B', NULL, NULL, 'SMC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(317, 'Manifold', 'SS5Y3-10L13-10B', NULL, NULL, 'SMC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(318, 'Manifold', 'SS5Y3-10L13-12B', NULL, NULL, 'SMC', NULL, 0, NULL, '2025-07-11 16:38:58'),
(319, '', 'SY30M-14-4A-1-3', NULL, NULL, 'SMC', NULL, 0, NULL, '2025-07-11 16:38:59'),
(320, 'Güç ve kontrol kabloları 0,6/1,0 kV', '5G4 YSLY-JB', NULL, NULL, 'TSE', NULL, 0, NULL, '2025-07-11 16:38:59'),
(321, 'Güç ve kontrol kabloları', '7G0,75 YSLY-JZ', NULL, NULL, 'TSE', NULL, 0, NULL, '2025-07-11 16:38:59'),
(322, 'Güç ve kontrol kabloları', '18G0,75 YSLY-JZ', NULL, '44', 'TSE', NULL, 1, NULL, '2025-07-11 16:38:59'),
(323, 'Güç ve kontrol kabloları 0,6/1,0 kV', '4G2,5 YSLY-JB', NULL, NULL, 'TSE', NULL, 0, NULL, '2025-07-11 16:38:59'),
(324, 'Güç ve kontrol kabloları', '3G0,75 YSLY-JZ', NULL, NULL, 'TSE', NULL, 0, NULL, '2025-07-11 16:38:59'),
(325, 'Güç ve kontrol kabloları', '25G0,5 YSLY-JZ', NULL, NULL, 'TSE', NULL, 0, NULL, '2025-07-11 16:38:59'),
(326, 'Güç ve kontrol kabloları 0,6/1,0 kV', '3G1,5 YSLY-JB', NULL, NULL, 'TSE', NULL, 0, NULL, '2025-07-11 16:38:59'),
(327, '220VAC Led armatür. Soketi ve 1 metre kablosu dahil.', 'TLPA-10W', NULL, NULL, 'Trio', NULL, 0, NULL, '2025-07-11 16:38:59'),
(328, 'RAY TİPİ PRİZ 16A 250V', 'VSR-G16', NULL, NULL, 'VIKO', NULL, 0, NULL, '2025-07-11 16:38:59'),
(329, 'Cisimden Yansımalı Sensör Arka Fon Bastırmalı', 'P1KH006', NULL, NULL, 'WGL', NULL, 0, NULL, '2025-07-11 16:38:59'),
(330, 'İndüktif sensör arttırılmış anahtarlama mesafeli', 'I12H006', NULL, NULL, 'WGL', NULL, 0, NULL, '2025-07-11 16:38:59'),
(331, 'Cisimden Yansımalı Sensör', 'U1KT001', NULL, NULL, 'WGL', NULL, 0, NULL, '2025-07-11 16:38:59'),
(332, '', '105698', NULL, NULL, '', NULL, 0, NULL, '2025-07-11 17:36:07'),
(333, '', '987654321', NULL, NULL, '', NULL, 0, NULL, '2025-07-11 17:36:07'),
(334, 'uBRİTO14', 'ES', NULL, '1', NULL, NULL, 1, NULL, '2025-07-12 11:23:05'),
(335, 'vaio', NULL, NULL, '258852', NULL, NULL, 0, NULL, '2025-07-13 15:48:39'),
(336, '5 servo sürüc', '23', NULL, '5', NULL, NULL, 2, NULL, '2025-07-13 19:00:03');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun_depo_konum`
--

CREATE TABLE `urun_depo_konum` (
  `urun_id` int(11) NOT NULL,
  `depo_konum_id` int(11) NOT NULL,
  `miktar` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun_hareketleri`
--

CREATE TABLE `urun_hareketleri` (
  `id` int(11) NOT NULL,
  `urun_id` int(11) NOT NULL,
  `hareket_turu` enum('Giris','Cikis') NOT NULL,
  `miktar` int(11) NOT NULL,
  `log_date` datetime DEFAULT current_timestamp(),
  `kullanici_id` int(11) NOT NULL,
  `aciklama` text DEFAULT NULL,
  `islem_turu_id` tinyint(4) DEFAULT NULL,
  `proje_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `urun_hareketleri`
--

INSERT INTO `urun_hareketleri` (`id`, `urun_id`, `hareket_turu`, `miktar`, `log_date`, `kullanici_id`, `aciklama`, `islem_turu_id`, `proje_id`) VALUES
(71, 256, 'Giris', 1, '2025-07-11 15:05:19', 1, NULL, 0, NULL),
(72, 256, 'Giris', 1, '2025-07-11 15:05:27', 1, NULL, 0, NULL),
(73, 256, 'Giris', 1, '2025-07-11 15:08:36', 1, NULL, 0, NULL),
(74, 256, 'Giris', 1, '2025-07-11 15:08:42', 1, NULL, 0, NULL),
(75, 256, 'Giris', 1, '2025-07-11 15:12:44', 1, NULL, 0, NULL),
(76, 256, 'Giris', 1, '2025-07-11 15:13:30', 1, NULL, 0, NULL),
(91, 263, 'Giris', 1, '2025-07-11 16:39:46', 1, NULL, 0, NULL),
(92, 259, 'Giris', 1, '2025-07-11 17:04:41', 1, NULL, 0, NULL),
(93, 256, 'Giris', 1, '2025-07-12 10:37:35', 1, NULL, 0, NULL),
(94, 256, 'Giris', 1, '2025-07-12 10:37:37', 1, NULL, 0, NULL),
(95, 256, 'Giris', 1, '2025-07-12 10:37:41', 1, NULL, 0, NULL),
(96, 256, 'Giris', 1, '2025-07-12 10:55:23', 1, NULL, 0, NULL),
(97, 256, 'Giris', 1, '2025-07-12 10:55:28', 1, NULL, 0, NULL),
(98, 256, 'Giris', 1, '2025-07-12 10:55:35', 1, NULL, 0, NULL),
(99, 256, 'Giris', 1, '2025-07-12 11:05:58', 1, NULL, 0, NULL),
(112, 334, 'Cikis', 1, '2025-07-13 01:23:22', 1, NULL, 0, NULL),
(113, 260, 'Cikis', 1, '2025-07-13 01:44:56', 1, NULL, 1, 39),
(114, 286, 'Cikis', 1, '2025-07-13 15:50:54', 1, NULL, 1, 39),
(115, 335, 'Cikis', 1, '2025-07-13 18:16:58', 1, NULL, 2, NULL),
(116, 335, 'Cikis', 1, '2025-07-13 18:17:03', 1, NULL, 2, NULL),
(117, 335, 'Cikis', 1, '2025-07-13 18:17:07', 1, NULL, 2, NULL),
(118, 335, 'Cikis', 1, '2025-07-13 18:32:48', 1, NULL, 2, NULL),
(119, 335, 'Cikis', 1, '2025-07-13 18:32:51', 1, NULL, 2, NULL),
(120, 336, 'Giris', 1, '2025-07-13 19:00:03', 1, NULL, 0, NULL),
(121, 336, 'Giris', 1, '2025-07-13 19:00:07', 1, NULL, 0, NULL),
(122, 334, 'Giris', 1, '2025-07-13 20:53:08', 1, NULL, 0, NULL);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `depo_konum`
--
ALTER TABLE `depo_konum`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `kat` (`kat`,`konum`);

--
-- Tablo için indeksler `islem_turu`
--
ALTER TABLE `islem_turu`
  ADD PRIMARY KEY (`islem_turu_id`);

--
-- Tablo için indeksler `kullanicilar`
--
ALTER TABLE `kullanicilar`
  ADD PRIMARY KEY (`kullanici_id`),
  ADD UNIQUE KEY `kullanici_adi` (`kullanici_adi`);

--
-- Tablo için indeksler `projeler`
--
ALTER TABLE `projeler`
  ADD PRIMARY KEY (`proje_id`),
  ADD KEY `fk_projeler_kullanici` (`olusturan_id`);

--
-- Tablo için indeksler `proje_hareketleri`
--
ALTER TABLE `proje_hareketleri`
  ADD PRIMARY KEY (`id`),
  ADD KEY `proje_id` (`proje_id`),
  ADD KEY `urun_id` (`urun_id`),
  ADD KEY `kullanici_id` (`kullanici_id`);

--
-- Tablo için indeksler `proje_urunleri`
--
ALTER TABLE `proje_urunleri`
  ADD PRIMARY KEY (`id`),
  ADD KEY `proje_id` (`proje_id`),
  ADD KEY `urun_id` (`urun_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Tablo için indeksler `urunler`
--
ALTER TABLE `urunler`
  ADD PRIMARY KEY (`urun_id`),
  ADD UNIQUE KEY `urun_kodu` (`urun_kodu`),
  ADD UNIQUE KEY `urun_barkod` (`urun_barkod`);

--
-- Tablo için indeksler `urun_depo_konum`
--
ALTER TABLE `urun_depo_konum`
  ADD PRIMARY KEY (`urun_id`,`depo_konum_id`),
  ADD KEY `fk_udk_depo` (`depo_konum_id`);

--
-- Tablo için indeksler `urun_hareketleri`
--
ALTER TABLE `urun_hareketleri`
  ADD PRIMARY KEY (`id`),
  ADD KEY `urun_id` (`urun_id`),
  ADD KEY `kullanici_id` (`kullanici_id`),
  ADD KEY `islem_turu_id` (`islem_turu_id`),
  ADD KEY `fk_urun_hareketleri_proje` (`proje_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `depo_konum`
--
ALTER TABLE `depo_konum`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tablo için AUTO_INCREMENT değeri `kullanicilar`
--
ALTER TABLE `kullanicilar`
  MODIFY `kullanici_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Tablo için AUTO_INCREMENT değeri `projeler`
--
ALTER TABLE `projeler`
  MODIFY `proje_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- Tablo için AUTO_INCREMENT değeri `proje_hareketleri`
--
ALTER TABLE `proje_hareketleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- Tablo için AUTO_INCREMENT değeri `proje_urunleri`
--
ALTER TABLE `proje_urunleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1351;

--
-- Tablo için AUTO_INCREMENT değeri `urunler`
--
ALTER TABLE `urunler`
  MODIFY `urun_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=337;

--
-- Tablo için AUTO_INCREMENT değeri `urun_hareketleri`
--
ALTER TABLE `urun_hareketleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=123;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `projeler`
--
ALTER TABLE `projeler`
  ADD CONSTRAINT `fk_projeler_kullanici` FOREIGN KEY (`olusturan_id`) REFERENCES `kullanicilar` (`kullanici_id`) ON DELETE SET NULL;

--
-- Tablo kısıtlamaları `proje_hareketleri`
--
ALTER TABLE `proje_hareketleri`
  ADD CONSTRAINT `proje_hareketleri_ibfk_1` FOREIGN KEY (`proje_id`) REFERENCES `projeler` (`proje_id`),
  ADD CONSTRAINT `proje_hareketleri_ibfk_2` FOREIGN KEY (`urun_id`) REFERENCES `urunler` (`urun_id`),
  ADD CONSTRAINT `proje_hareketleri_ibfk_3` FOREIGN KEY (`kullanici_id`) REFERENCES `kullanicilar` (`kullanici_id`);

--
-- Tablo kısıtlamaları `proje_urunleri`
--
ALTER TABLE `proje_urunleri`
  ADD CONSTRAINT `proje_urunleri_ibfk_1` FOREIGN KEY (`proje_id`) REFERENCES `projeler` (`proje_id`),
  ADD CONSTRAINT `proje_urunleri_ibfk_2` FOREIGN KEY (`urun_id`) REFERENCES `urunler` (`urun_id`),
  ADD CONSTRAINT `proje_urunleri_ibfk_3` FOREIGN KEY (`user_id`) REFERENCES `kullanicilar` (`kullanici_id`);

--
-- Tablo kısıtlamaları `urun_depo_konum`
--
ALTER TABLE `urun_depo_konum`
  ADD CONSTRAINT `fk_udk_depo` FOREIGN KEY (`depo_konum_id`) REFERENCES `depo_konum` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_udk_urun` FOREIGN KEY (`urun_id`) REFERENCES `urunler` (`urun_id`) ON DELETE CASCADE;

--
-- Tablo kısıtlamaları `urun_hareketleri`
--
ALTER TABLE `urun_hareketleri`
  ADD CONSTRAINT `fk_urun_hareketleri_proje` FOREIGN KEY (`proje_id`) REFERENCES `projeler` (`proje_id`),
  ADD CONSTRAINT `urun_hareketleri_ibfk_1` FOREIGN KEY (`urun_id`) REFERENCES `urunler` (`urun_id`),
  ADD CONSTRAINT `urun_hareketleri_ibfk_2` FOREIGN KEY (`kullanici_id`) REFERENCES `kullanicilar` (`kullanici_id`),
  ADD CONSTRAINT `urun_hareketleri_ibfk_3` FOREIGN KEY (`islem_turu_id`) REFERENCES `islem_turu` (`islem_turu_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
