-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 23 Tem 2025, 12:20:26
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
  `harf` varchar(50) NOT NULL,
  `numara` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `depo_konum`
--

INSERT INTO `depo_konum` (`id`, `harf`, `numara`) VALUES
(7, 'A', '1'),
(8, 'A', '2'),
(9, 'A', '3'),
(10, 'E', '5'),
(11, 'Y', '8'),
(12, 'Z', '5');

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
  `kayit_tarihi` datetime DEFAULT current_timestamp(),
  `silindi` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `kullanicilar`
--

INSERT INTO `kullanicilar` (`kullanici_id`, `kullanici_adi`, `sifre`, `kullanici_yetki`, `ad_soyad`, `aktif`, `kayit_tarihi`, `silindi`) VALUES
(1, 'admin', 'admin', 1, 'Sistem Yöneticisi', 1, '2025-07-04 13:59:18', 0),
(2, 'kullanici', 'fccf00907c168fffd34a79979bddfeec1e97892c', 2, 'Standart Kullanıcı', 0, '2025-07-04 13:59:18', 1),
(11, 'omerd', '123', 2, 'omer d', 1, '2025-07-18 09:34:05', 1),
(13, 'user1', '123', 2, 'user', 1, '2025-07-18 10:57:11', 0);

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
(42, 'E666', 'E666 VANA OTOMASYONU', 0, '2025-07-13 21:47:49', 1),
(43, 'buzdagi', 'buzdagi', 1, '2025-07-17 12:47:29', 1),
(44, 'buzdagi1', 'buzdagi1', 0, '2025-07-21 12:37:32', 1),
(45, 'E476', 'E476 VANA OTOMASYONU', 1, '2025-07-22 12:55:23', 1);

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
  `islem_tarihi` datetime DEFAULT current_timestamp(),
  `aktif` tinyint(1) NOT NULL DEFAULT 1,
  `geri_alinan_islem` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `proje_hareketleri`
--

INSERT INTO `proje_hareketleri` (`id`, `proje_id`, `urun_id`, `miktar`, `kullanici_id`, `islem_tarihi`, `aktif`, `geri_alinan_islem`) VALUES
(20, 39, 260, 1, 1, '2025-07-13 01:44:56', 0, NULL),
(55, 43, 341, 1, 1, '2025-07-17 12:48:01', 0, '2025-07-17 13:08:05'),
(56, 43, 341, 1, 1, '2025-07-17 12:48:08', 0, '2025-07-17 13:07:59'),
(57, 43, 341, 2, 1, '2025-07-17 12:48:15', 0, '2025-07-17 12:54:27'),
(58, 43, 341, 1, 1, '2025-07-17 13:47:41', 0, '2025-07-17 13:47:50'),
(59, 43, 341, 1, 1, '2025-07-17 13:48:34', 0, '2025-07-17 13:54:23'),
(60, 43, 341, 2, 1, '2025-07-17 13:48:41', 0, '2025-07-17 13:49:59'),
(61, 43, 341, 1, 1, '2025-07-17 13:50:06', 0, '2025-07-17 14:20:36'),
(62, 43, 341, 3, 1, '2025-07-17 13:54:17', 0, '2025-07-17 13:54:26'),
(63, 43, 341, 1, 1, '2025-07-17 14:20:22', 0, '2025-07-17 14:20:36'),
(64, 43, 327, 1, 1, '2025-07-17 14:33:11', 0, '2025-07-17 14:33:27'),
(65, 43, 341, 1, 1, '2025-07-17 14:46:09', 0, '2025-07-17 15:46:57'),
(66, 43, 336, 1, 1, '2025-07-17 14:48:17', 0, '2025-07-17 15:52:18'),
(67, 43, 336, 4, 1, '2025-07-17 14:51:13', 0, '2025-07-17 15:52:20'),
(68, 43, 336, 1, 1, '2025-07-17 17:47:28', 0, '2025-07-17 17:47:47'),
(69, 43, 261, 1, 1, '2025-07-18 09:12:28', 0, '2025-07-18 09:14:05'),
(70, 43, 327, 1, 1, '2025-07-18 09:15:20', 0, '2025-07-18 09:19:44'),
(71, 43, 316, 4, 1, '2025-07-18 10:38:16', 0, '2025-07-18 10:38:32'),
(72, 43, 316, 1, 1, '2025-07-18 10:38:36', 0, '2025-07-18 10:39:08'),
(73, 43, 316, 3, 1, '2025-07-18 10:39:02', 0, '2025-07-18 10:39:06'),
(74, 43, 316, 1, 1, '2025-07-18 10:46:53', 1, NULL),
(75, 43, 316, 1, 1, '2025-07-18 10:46:54', 1, NULL),
(76, 43, 261, 1, 1, '2025-07-18 11:50:43', 0, '2025-07-18 11:50:48'),
(77, 43, 261, 6, 1, '2025-07-18 12:29:00', 1, NULL),
(78, 43, 327, 1, 1, '2025-07-22 11:24:44', 1, NULL),
(79, 43, 327, 1, 1, '2025-07-22 11:24:49', 1, NULL),
(80, 43, 327, 1, 1, '2025-07-22 11:25:20', 1, NULL),
(81, 43, 327, 1, 1, '2025-07-22 11:32:04', 1, NULL),
(82, 43, 327, 1, 1, '2025-07-22 11:57:08', 1, NULL),
(83, 43, 327, 1, 1, '2025-07-22 12:01:53', 0, '2025-07-22 12:08:15'),
(84, 43, 327, 1, 1, '2025-07-22 12:02:08', 0, '2025-07-22 12:08:13'),
(85, 43, 327, 1, 1, '2025-07-22 12:27:15', 1, NULL),
(86, 43, 327, 1, 1, '2025-07-22 12:27:20', 1, NULL),
(87, 43, 327, 1, 1, '2025-07-23 08:56:31', 1, NULL),
(88, 43, 327, 1, 1, '2025-07-23 09:12:00', 1, NULL),
(89, 43, 327, 2, 1, '2025-07-23 09:13:07', 0, '2025-07-23 09:23:28'),
(90, 43, 327, 1, 1, '2025-07-23 09:22:11', 0, '2025-07-23 09:22:57'),
(91, 43, 327, 3, 1, '2025-07-23 09:26:42', 1, NULL),
(92, 43, 327, 1, 1, '2025-07-23 09:32:21', 1, NULL),
(93, 43, 327, 1, 1, '2025-07-23 09:34:37', 0, '2025-07-23 09:34:44'),
(94, 43, 327, 1, 1, '2025-07-23 09:42:19', 1, NULL),
(95, 43, 327, 1, 1, '2025-07-23 09:42:24', 1, NULL),
(96, 43, 327, 1, 1, '2025-07-23 09:42:28', 1, NULL),
(97, 43, 327, 1, 1, '2025-07-23 09:42:31', 1, NULL),
(98, 43, 327, 1, 1, '2025-07-23 09:42:36', 1, NULL);

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
(1359, 43, 261, 8, '2025-07-17 16:01:45', 1),
(1361, 43, 327, 19, '2025-07-17 17:46:38', 1),
(1362, 43, 316, 4, '2025-07-18 10:36:22', 1),
(1363, 44, 341, 5, '2025-07-21 12:37:32', 1),
(1364, 44, 256, 2, '2025-07-21 12:37:32', 1),
(1365, 43, 259, 1, '2025-07-22 08:48:06', 1),
(1366, 45, 259, 1, '2025-07-22 12:55:23', 1),
(1367, 45, 260, 1, '2025-07-22 12:55:23', 1),
(1368, 45, 261, 14, '2025-07-22 12:55:23', 1),
(1369, 45, 262, 1, '2025-07-22 12:55:23', 1),
(1370, 45, 263, 2, '2025-07-22 12:55:23', 1),
(1371, 45, 264, 3, '2025-07-22 12:55:23', 1),
(1372, 45, 265, 1, '2025-07-22 12:55:23', 1),
(1373, 45, 266, 1, '2025-07-22 12:55:23', 1),
(1374, 45, 267, 2, '2025-07-22 12:55:23', 1),
(1375, 45, 268, 1, '2025-07-22 12:55:23', 1),
(1376, 45, 269, 1, '2025-07-22 12:55:23', 1),
(1377, 45, 270, 12, '2025-07-22 12:55:23', 1),
(1378, 45, 271, 73, '2025-07-22 12:55:23', 1),
(1379, 45, 272, 10, '2025-07-22 12:55:23', 1),
(1380, 45, 273, 5, '2025-07-22 12:55:23', 1),
(1381, 45, 274, 39, '2025-07-22 12:55:23', 1),
(1382, 45, 275, 146, '2025-07-22 12:55:23', 1),
(1383, 45, 276, 1, '2025-07-22 12:55:23', 1),
(1384, 45, 277, 1, '2025-07-22 12:55:23', 1),
(1385, 45, 278, 1, '2025-07-22 12:55:23', 1),
(1386, 45, 279, 23, '2025-07-22 12:55:23', 1),
(1387, 45, 280, 22, '2025-07-22 12:55:23', 1),
(1388, 45, 281, 4, '2025-07-22 12:55:23', 1),
(1389, 45, 282, 1, '2025-07-22 12:55:23', 1),
(1390, 45, 283, 1, '2025-07-22 12:55:23', 1),
(1391, 45, 284, 6, '2025-07-22 12:55:23', 1),
(1392, 45, 285, 9, '2025-07-22 12:55:23', 1),
(1393, 45, 286, 28, '2025-07-22 12:55:23', 1),
(1394, 45, 287, 2, '2025-07-22 12:55:23', 1),
(1395, 45, 288, 22, '2025-07-22 12:55:23', 1),
(1396, 45, 289, 2, '2025-07-22 12:55:23', 1),
(1397, 45, 290, 12, '2025-07-22 12:55:23', 1),
(1398, 45, 291, 45, '2025-07-22 12:55:23', 1),
(1399, 45, 292, 1, '2025-07-22 12:55:23', 1),
(1400, 45, 293, 95, '2025-07-22 12:55:23', 1),
(1401, 45, 294, 1, '2025-07-22 12:55:23', 1),
(1402, 45, 295, 1, '2025-07-22 12:55:23', 1),
(1403, 45, 296, 1, '2025-07-22 12:55:23', 1),
(1404, 45, 297, 1, '2025-07-22 12:55:23', 1),
(1405, 45, 298, 1, '2025-07-22 12:55:23', 1),
(1406, 45, 299, 5, '2025-07-22 12:55:24', 1),
(1407, 45, 300, 3, '2025-07-22 12:55:24', 1),
(1408, 45, 301, 7, '2025-07-22 12:55:24', 1),
(1409, 45, 302, 1, '2025-07-22 12:55:24', 1),
(1410, 45, 303, 2, '2025-07-22 12:55:24', 1),
(1411, 45, 304, 2, '2025-07-22 12:55:24', 1),
(1412, 45, 305, 2, '2025-07-22 12:55:24', 1),
(1413, 45, 306, 1, '2025-07-22 12:55:24', 1),
(1414, 45, 307, 1, '2025-07-22 12:55:24', 1),
(1415, 45, 308, 1, '2025-07-22 12:55:24', 1),
(1416, 45, 309, 2, '2025-07-22 12:55:24', 1),
(1417, 45, 310, 1, '2025-07-22 12:55:24', 1),
(1418, 45, 311, 1, '2025-07-22 12:55:24', 1),
(1419, 45, 312, 1, '2025-07-22 12:55:24', 1),
(1420, 45, 313, 1, '2025-07-22 12:55:24', 1),
(1421, 45, 314, 35, '2025-07-22 12:55:24', 1),
(1422, 45, 315, 4, '2025-07-22 12:55:24', 1),
(1423, 45, 316, 1, '2025-07-22 12:55:24', 1),
(1424, 45, 317, 1, '2025-07-22 12:55:24', 1),
(1425, 45, 318, 1, '2025-07-22 12:55:24', 1),
(1426, 45, 319, 4, '2025-07-22 12:55:24', 1),
(1427, 45, 320, 1, '2025-07-22 12:55:24', 1),
(1428, 45, 321, 3, '2025-07-22 12:55:24', 1),
(1429, 45, 322, 1, '2025-07-22 12:55:24', 1),
(1430, 45, 323, 1, '2025-07-22 12:55:24', 1),
(1431, 45, 324, 5, '2025-07-22 12:55:24', 1),
(1432, 45, 325, 5, '2025-07-22 12:55:24', 1),
(1433, 45, 326, 2, '2025-07-22 12:55:24', 1),
(1434, 45, 327, 1, '2025-07-22 12:55:24', 1),
(1435, 45, 328, 1, '2025-07-22 12:55:24', 1),
(1436, 45, 329, 6, '2025-07-22 12:55:24', 1),
(1437, 45, 330, 5, '2025-07-22 12:55:24', 1),
(1438, 45, 331, 1, '2025-07-22 12:55:24', 1);

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
  `birim` enum('adet','metre','cm') NOT NULL DEFAULT 'adet',
  `kritik_seviye` int(11) DEFAULT NULL,
  `kayit_tarihi` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `urunler`
--

INSERT INTO `urunler` (`urun_id`, `urun_adi`, `urun_kodu`, `aciklama`, `urun_barkod`, `urun_marka`, `urun_no`, `miktar`, `birim`, `kritik_seviye`, `kayit_tarihi`) VALUES
(256, 'Klemens', '50130833', NULL, NULL, 'LEU', NULL, 69, 'adet', 10, '2025-07-11 14:26:57'),
(259, '4 Gerilim girişi/Akım girişi', 'AS04AD-A', NULL, '47', 'DEP', NULL, 10, 'adet', NULL, '2025-07-11 16:38:58'),
(260, 'AS200 PLC - 16DI / 12DO PNP, Dahili Ethernet / CAN', 'AS228P-A', NULL, NULL, 'DEL', NULL, 6, 'adet', NULL, '2025-07-11 16:38:58'),
(261, 'AS16AP11P-A ,8D/8P Plc Ek Dijital Modül', 'AS16AP11P-A', NULL, '200', 'DEL', NULL, 95, 'adet', NULL, '2025-07-11 16:38:58'),
(262, 'Endüstriyel Ethernet DIACloud Bulut Yönlendiriciler', 'DX-2300LN-WW', NULL, NULL, 'DEL', NULL, 3, 'adet', NULL, '2025-07-11 16:38:58'),
(263, 'A2 Servo Sürücü - 1000W', 'ASD-A2-1021-M', NULL, '0', 'DEL', NULL, 1, 'adet', NULL, '2025-07-11 16:38:58'),
(264, 'A2 Servo Sürücü - 400 Watt', 'ASD-A2-0421-M', NULL, '25', 'LEU', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(265, 'Pano Soğutma Termostat\'ı 0-70°C Ray Tipi - Emas 10A 230V AC', 'PTM111', NULL, '6664444466666', 'EMAS', NULL, 1, 'adet', NULL, '2025-07-11 16:38:58'),
(266, 'Pimli Plastik Kapı Switch - NC contact type', 'BS1010', NULL, '799', 'EMAS', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(267, 'Vibrasyon Kontrol Cihazı', 'EPAC3-W-F', NULL, '965', 'ENDA', NULL, 1, 'adet', NULL, '2025-07-11 16:38:58'),
(268, 'Faz yokluğu, Faz sırası hatası, 1 N/O kontak DIN1 Ray Montaj', 'MKS-03', NULL, NULL, 'ENTES', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(269, 'HMI 10” TFT, 1024x600, Dirençli dokunmatik, 4 GB Flash bellek, 1x Ethernet, JMobile çalışma zamanı', 'ESMA10U301', NULL, '346', 'EXOR', NULL, 1, 'adet', NULL, '2025-07-11 16:38:58'),
(270, 'Transistör Çıkış Kartı 8\'li', 'GT8-V11', NULL, NULL, 'GEM', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(271, 'Bağlantı kablosu', '50130832', NULL, NULL, 'LEU', NULL, 72, 'adet', NULL, '2025-07-11 16:38:58'),
(272, 'Bağlantı kablosu', '50130690', NULL, NULL, 'LEU', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(273, 'EXACT12, 8XM12, 5-KUTUPLU, KAPAK, FIŞ. VİDA TERM.', '8000-88550-0000000', NULL, NULL, 'MURR', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(274, 'Sensör aktüatör adaptörü', '7000-41201-0000000', NULL, NULL, 'MURR', '123', 0, 'adet', NULL, '2025-07-11 16:38:58'),
(275, 'Dairesel konektör (saha montajı için)', '7000-08601-0000000', NULL, NULL, 'MURR', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(276, 'Güç kaynağı 24V 10A 240W 24~28 V', 'NDR-240-24', NULL, NULL, 'MW', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(277, 'Tek katlı tepe lambası + Buzzer', 'SNT-7024-SB1', NULL, NULL, 'Mucco', NULL, 1, 'adet', NULL, '2025-07-11 16:38:58'),
(278, 'İki elli şalt cihazı', '774350', NULL, NULL, 'PILZ', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(279, 'Terminal bloğu için uç braketi', '3022276', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(280, 'Klemens dizisi etiket taşıyıcı', '0811969', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(281, 'Geçişli terminal bloğu', '3211757', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(282, 'Topraklama modüler terminal bloğu', '3211766', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(283, 'Terminal bloğu için uç ve bölme plakası', '3030420', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(284, 'Topraklama modüler terminal bloğu', '3209536', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(285, 'Terminal bloğu için uç ve bölme plakası', '3030417', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(286, 'Geçişli terminal bloğu', '3209523', NULL, NULL, 'PXC', NULL, 3, 'adet', NULL, '2025-07-11 16:38:58'),
(287, 'Geçmeli köprü', '3030174', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(288, 'Geçişli terminal bloğu', '3209512', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(289, 'Geçmeli köprü', '3030161', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(290, 'Sigortalı modüler klemens', '3036547', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(291, 'Geçişli terminal bloğu', '3209510', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(292, 'Röle Modülü', '2900299', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(293, 'Çift seviyeli terminal bloğu', '3210567', NULL, NULL, 'PXC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(294, 'FANLI FILTRE 108 m3/h 162X162X65mm', 'FULL1500', NULL, NULL, 'QUICK', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(295, 'Panel Filtre (162x162x24mm) KESİM=125x125', 'FIL1500', NULL, NULL, 'QUICK', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(296, 'Minyatür devre kesici iC60N, 3P, 16A, C', 'A9F74316', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(297, 'TeSys Vario - kapı üzerinde acil durdurma şalteri ayırıcısı', 'VCF01', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(298, 'Minyatür devre kesici iC60N, 3P, 2A, C', 'A9F74302', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(299, 'Minyatür devre kesici iC60N, 1P, 4A, C', 'A9F74104', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(300, 'Beyaz komple pilot lambası Ø22 entegre LED\'li düz lens 230...240V', 'XB4BVM1', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(301, 'Minyatür devre kesici iC60N, 1P, 10A, C', 'A9F74110', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(302, 'TeSys K kontaktör - 3P(3 NA) - AC-3 - <= 440 V 6 A - 24 V DC bobin', 'LP1K0610BD', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(303, 'Kırmızı Ø40 Acil durdurma, kapatma Ø22 mandallı dönüş serbest bırakma 1NK 600VAC', 'XB4BS8442', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(304, 'Siyah Ø40 mantar Buton Ø22 yaylı dönüş 1NA', 'XB4BC21', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(305, 'Harmony XB5 1NK kontağı', 'ZBE102', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(306, 'Kontaktör TeSys LC1-D - 3P - AC-3 440V 9 A, Bobin 24 V DC', 'LC1D09BD', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(307, 'Termik Manyetik Motorlu Devre Kesici TeSys GV2ME - 3P - 1...1.6 A', 'GV2ME06', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(308, 'TeSys GVAE11 - yardımcı kontak - 1 NA + 1 NK', 'GVAE11', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(309, 'Minyatür devre kesici iC60N, 1P, 16A, C', 'A9F74116', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(310, 'Siyah seçim anahtarı Ø22 2 konumlu sabit 1NA 600V', 'XB4BD21', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(311, 'Yeşil sıva altı komple ışıklı buton Ø22 yaylı dönüş 1NA+1NK 24V', 'XB4BW33B5', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(312, 'Kırmızı gömme komple buton Ø22 yay geri dönüşlü 1NC \"işaretsiz\"', 'XB4BA42', NULL, NULL, 'SE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(313, 'Manifold', 'SS5Y3-10L13-09B', NULL, NULL, 'SMC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(314, 'SY3000, 5 Portlu Solenoid Valf, Tüm Tipler - Yeni Stil', 'SY3200-5U1', NULL, NULL, 'SMC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(315, 'KÖRLEME PLAKASI TAKIMI', 'SY30M-26-1A', NULL, NULL, 'SMC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(316, 'Manifold', 'SS5Y3-10L13-08B', NULL, '900', 'SMC', NULL, 98, 'adet', NULL, '2025-07-11 16:38:58'),
(317, 'Manifold', 'SS5Y3-10L13-10B', NULL, NULL, 'SMC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(318, 'Manifold', 'SS5Y3-10L13-12B', NULL, NULL, 'SMC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:58'),
(319, '', 'SY30M-14-4A-1-3', NULL, NULL, 'SMC', NULL, 0, 'adet', NULL, '2025-07-11 16:38:59'),
(320, 'Güç ve kontrol kabloları 0,6/1,0 kV', '5G4 YSLY-JB', NULL, NULL, 'TSE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:59'),
(321, 'Güç ve kontrol kabloları', '7G0,75 YSLY-JZ', NULL, NULL, 'TSE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:59'),
(322, 'Güç ve kontrol kabloları', '18G0,75 YSLY-JZ', NULL, '44', 'TSE', NULL, 1, 'adet', NULL, '2025-07-11 16:38:59'),
(323, 'Güç ve kontrol kabloları 0,6/1,0 kV', '4G2,5 YSLY-JB', NULL, NULL, 'TSE', NULL, 1, 'adet', NULL, '2025-07-11 16:38:59'),
(324, 'Güç ve kontrol kabloları', '3G0,75 YSLY-JZ', NULL, NULL, 'TSE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:59'),
(325, 'Güç ve kontrol kabloları', '25G0,5 YSLY-JZ', NULL, NULL, 'TSE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:59'),
(326, 'Güç ve kontrol kabloları 0,6/1,0 kV', '3G1,5 YSLY-JB', NULL, NULL, 'TSE', NULL, 0, 'adet', NULL, '2025-07-11 16:38:59'),
(327, '220VAC Led armatür. Soketi ve 1 metre kablosu dahil.', 'TLPA-10W', NULL, '800', 'Trio', NULL, 67, 'adet', NULL, '2025-07-11 16:38:59'),
(328, 'RAY TİPİ PRİZ 16A 250V', 'VSR-G16', NULL, NULL, 'VIKO', NULL, 0, 'adet', NULL, '2025-07-11 16:38:59'),
(329, 'Cisimden Yansımalı Sensör Arka Fon Bastırmalı', 'P1KH006', NULL, NULL, 'WGL', NULL, 0, 'adet', NULL, '2025-07-11 16:38:59'),
(330, 'İndüktif sensör arttırılmış anahtarlama mesafeli', 'I12H006', NULL, NULL, 'WGL', NULL, 0, 'adet', NULL, '2025-07-11 16:38:59'),
(331, 'Cisimden Yansımalı Sensör', 'U1KT001', NULL, '', 'WGL', NULL, 1, 'adet', NULL, '2025-07-11 16:38:59'),
(332, '', '105698', NULL, NULL, '', NULL, 0, 'adet', NULL, '2025-07-11 17:36:07'),
(333, '', '987654321', NULL, NULL, '', NULL, 0, 'adet', NULL, '2025-07-11 17:36:07'),
(334, 'uBRİTO14', 'ES', NULL, '1', NULL, NULL, 2, 'adet', NULL, '2025-07-12 11:23:05'),
(335, 'vaio', NULL, NULL, '258852', NULL, NULL, 0, 'adet', NULL, '2025-07-13 15:48:39'),
(336, '5 servo sürücü', '23', NULL, '7', NULL, NULL, 155, 'adet', NULL, '2025-07-13 19:00:03'),
(337, 'Servo sürücü 4asd', 'AST9999', NULL, NULL, 'ETX', NULL, 7, 'adet', NULL, '2025-07-14 10:11:06'),
(338, 'hp', 'vby45', NULL, '64', NULL, NULL, 1, 'adet', NULL, '2025-07-14 12:38:44'),
(339, 'olk', 'öçl', NULL, '1290666', NULL, NULL, 1, 'adet', NULL, '2025-07-14 12:39:34'),
(340, 'servo', '126', NULL, '15', NULL, NULL, 2, 'adet', NULL, '2025-07-14 13:26:02'),
(341, 'buzdagi', 'bzdg123', NULL, '8699878420755', NULL, NULL, 11, 'adet', NULL, '2025-07-17 12:35:09'),
(342, 'KABLO556', 'BHJ654', NULL, '556', NULL, NULL, 10, 'adet', NULL, '2025-07-17 16:50:29'),
(343, 'kablo332', '332', NULL, '332', NULL, NULL, 2, 'adet', NULL, '2025-07-17 17:15:04'),
(344, 'kablo333', '333', NULL, '333', NULL, NULL, 300, 'metre', NULL, '2025-07-17 17:16:20'),
(352, 'praşendo', '164616', NULL, '113333', NULL, NULL, 1, 'adet', NULL, '2025-07-22 15:19:38'),
(353, 'MESSİTO', 'DAS', NULL, '551454649648941', NULL, NULL, 2, 'cm', NULL, '2025-07-22 16:15:54');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun_depo_konum`
--

CREATE TABLE `urun_depo_konum` (
  `urun_id` int(11) NOT NULL,
  `depo_konum_id` int(11) NOT NULL,
  `miktar` int(11) NOT NULL DEFAULT 1,
  `birim` varchar(20) DEFAULT 'adet'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `urun_depo_konum`
--

INSERT INTO `urun_depo_konum` (`urun_id`, `depo_konum_id`, `miktar`, `birim`) VALUES
(256, 7, 3, 'adet'),
(259, 7, 3, 'adet'),
(259, 11, 7, 'adet'),
(263, 9, 1, 'adet'),
(271, 7, 3, 'adet'),
(271, 8, 71, 'adet'),
(327, 7, 1, 'adet'),
(327, 8, 71, 'adet'),
(327, 9, 1, 'adet'),
(327, 11, 5, 'adet'),
(327, 12, 11, 'adet'),
(336, 7, 41, 'adet'),
(336, 8, 71, 'adet'),
(336, 9, 1, 'adet'),
(336, 12, 25, 'adet'),
(338, 8, 71, 'adet'),
(340, 7, 3, 'adet'),
(344, 7, 3, 'adet');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun_guncelleme_log`
--

CREATE TABLE `urun_guncelleme_log` (
  `log_id` int(11) NOT NULL,
  `urun_id` int(11) NOT NULL,
  `kolon_adi` enum('urun_adi','urun_kodu','urun_barkod','urun_marka','urun_no','kritik_seviye') NOT NULL,
  `eski_deger` text DEFAULT NULL,
  `yeni_deger` text DEFAULT NULL,
  `degistiren_id` int(11) NOT NULL,
  `degisiklik_tarihi` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `urun_guncelleme_log`
--

INSERT INTO `urun_guncelleme_log` (`log_id`, `urun_id`, `kolon_adi`, `eski_deger`, `yeni_deger`, `degistiren_id`, `degisiklik_tarihi`) VALUES
(1, 259, 'urun_barkod', '777', '776', 1, '2025-07-16 13:42:42'),
(2, 264, 'urun_barkod', '', '25', 1, '2025-07-21 11:54:12'),
(3, 264, 'urun_marka', 'DEL', 'LEU', 1, '2025-07-21 11:54:42'),
(4, 274, 'urun_marka', 'MURR', 'STX', 1, '2025-07-21 11:54:42'),
(5, 274, 'urun_no', '', '123', 1, '2025-07-21 11:54:42'),
(6, 274, 'urun_marka', 'STX', 'MURR', 1, '2025-07-22 08:45:57');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun_hareketleri`
--

CREATE TABLE `urun_hareketleri` (
  `id` int(11) NOT NULL,
  `urun_id` int(11) NOT NULL,
  `hareket_turu` enum('Giris','Cikis','Geri Alinan') NOT NULL,
  `miktar` int(11) NOT NULL,
  `log_date` datetime DEFAULT current_timestamp(),
  `kullanici_id` int(11) NOT NULL,
  `aciklama` text DEFAULT NULL,
  `islem_turu_id` tinyint(4) DEFAULT NULL,
  `proje_id` int(11) DEFAULT NULL,
  `depo_konum_id` int(11) DEFAULT NULL,
  `birim` varchar(20) DEFAULT 'adet'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `urun_hareketleri`
--

INSERT INTO `urun_hareketleri` (`id`, `urun_id`, `hareket_turu`, `miktar`, `log_date`, `kullanici_id`, `aciklama`, `islem_turu_id`, `proje_id`, `depo_konum_id`, `birim`) VALUES
(71, 256, 'Giris', 1, '2025-07-11 15:05:19', 1, NULL, 0, NULL, NULL, 'adet'),
(72, 256, 'Giris', 1, '2025-07-11 15:05:27', 1, NULL, 0, NULL, NULL, 'adet'),
(73, 256, 'Giris', 1, '2025-07-11 15:08:36', 1, NULL, 0, NULL, NULL, 'adet'),
(74, 256, 'Giris', 1, '2025-07-11 15:08:42', 1, NULL, 0, NULL, NULL, 'adet'),
(75, 256, 'Giris', 1, '2025-07-11 15:12:44', 1, NULL, 0, NULL, NULL, 'adet'),
(76, 256, 'Giris', 1, '2025-07-11 15:13:30', 1, NULL, 0, NULL, NULL, 'adet'),
(91, 263, 'Giris', 1, '2025-07-11 16:39:46', 1, NULL, 0, NULL, NULL, 'adet'),
(92, 259, 'Giris', 1, '2025-07-11 17:04:41', 1, NULL, 0, NULL, NULL, 'adet'),
(93, 256, 'Giris', 1, '2025-07-12 10:37:35', 1, NULL, 0, NULL, NULL, 'adet'),
(94, 256, 'Giris', 1, '2025-07-12 10:37:37', 1, NULL, 0, NULL, NULL, 'adet'),
(95, 256, 'Giris', 1, '2025-07-12 10:37:41', 1, NULL, 0, NULL, NULL, 'adet'),
(96, 256, 'Giris', 1, '2025-07-12 10:55:23', 1, NULL, 0, NULL, NULL, 'adet'),
(97, 256, 'Giris', 1, '2025-07-12 10:55:28', 1, NULL, 0, NULL, NULL, 'adet'),
(98, 256, 'Giris', 1, '2025-07-12 10:55:35', 1, NULL, 0, NULL, NULL, 'adet'),
(99, 256, 'Giris', 1, '2025-07-12 11:05:58', 1, NULL, 0, NULL, NULL, 'adet'),
(112, 334, 'Cikis', 1, '2025-07-13 01:23:22', 1, NULL, 0, NULL, NULL, 'adet'),
(113, 260, 'Cikis', 1, '2025-07-13 01:44:56', 1, NULL, 1, 39, NULL, 'adet'),
(114, 286, 'Cikis', 1, '2025-07-13 15:50:54', 1, NULL, 1, 39, NULL, 'adet'),
(115, 335, 'Cikis', 1, '2025-07-13 18:16:58', 1, NULL, 2, NULL, NULL, 'adet'),
(116, 335, 'Cikis', 1, '2025-07-13 18:17:03', 1, NULL, 2, NULL, NULL, 'adet'),
(117, 335, 'Cikis', 1, '2025-07-13 18:17:07', 1, NULL, 2, NULL, NULL, 'adet'),
(118, 335, 'Cikis', 1, '2025-07-13 18:32:48', 1, NULL, 2, NULL, NULL, 'adet'),
(119, 335, 'Cikis', 1, '2025-07-13 18:32:51', 1, NULL, 2, NULL, NULL, 'adet'),
(120, 336, 'Giris', 1, '2025-07-13 19:00:03', 1, NULL, 0, NULL, NULL, 'adet'),
(121, 336, 'Giris', 1, '2025-07-13 19:00:07', 1, NULL, 0, NULL, NULL, 'adet'),
(122, 334, 'Giris', 1, '2025-07-13 20:53:08', 1, NULL, 0, NULL, NULL, 'adet'),
(123, 271, 'Cikis', 69, '2025-07-14 08:23:32', 1, NULL, 1, 42, NULL, 'adet'),
(124, 271, 'Cikis', 1, '2025-07-14 08:23:48', 1, NULL, 1, 42, NULL, 'adet'),
(125, 271, 'Cikis', 1, '2025-07-14 08:23:55', 1, NULL, 1, 42, NULL, 'adet'),
(126, 271, 'Cikis', 1, '2025-07-14 08:24:00', 1, NULL, 1, 42, NULL, 'adet'),
(127, 260, 'Cikis', 1, '2025-07-14 08:32:13', 1, NULL, 1, 42, NULL, 'adet'),
(128, 267, 'Cikis', 1, '2025-07-14 08:58:07', 1, NULL, 1, 42, NULL, 'adet'),
(129, 267, 'Cikis', 1, '2025-07-14 09:37:14', 1, NULL, 1, 42, NULL, 'adet'),
(130, 267, 'Cikis', 1, '2025-07-14 09:37:24', 1, NULL, 1, 42, NULL, 'adet'),
(131, 267, 'Cikis', 1, '2025-07-14 09:47:01', 1, NULL, 1, 42, NULL, 'adet'),
(132, 337, 'Giris', 1, '2025-07-14 10:11:06', 1, NULL, 0, NULL, NULL, 'adet'),
(133, 334, 'Giris', 1, '2025-07-14 11:50:39', 1, NULL, 0, NULL, NULL, 'adet'),
(134, 334, 'Cikis', 1, '2025-07-14 11:50:50', 1, NULL, 0, NULL, NULL, 'adet'),
(135, 338, 'Giris', 1, '2025-07-14 12:38:44', 1, NULL, 0, NULL, NULL, 'adet'),
(136, 339, 'Giris', 1, '2025-07-14 12:39:34', 1, NULL, 0, NULL, NULL, 'adet'),
(137, 337, 'Giris', 1, '2025-07-14 12:40:57', 1, NULL, 0, NULL, NULL, 'adet'),
(138, 337, 'Giris', 1, '2025-07-14 12:41:02', 1, NULL, 0, NULL, NULL, 'adet'),
(139, 337, 'Giris', 1, '2025-07-14 12:41:17', 1, NULL, 0, NULL, NULL, 'adet'),
(140, 337, 'Giris', 1, '2025-07-14 12:41:53', 1, NULL, 0, NULL, NULL, 'adet'),
(141, 337, 'Giris', 1, '2025-07-14 12:41:56', 1, NULL, 0, NULL, NULL, 'adet'),
(142, 260, 'Giris', 1, '2025-07-14 12:42:07', 1, NULL, 0, NULL, NULL, 'adet'),
(143, 337, 'Giris', 1, '2025-07-14 12:43:04', 1, NULL, 0, NULL, NULL, 'adet'),
(144, 340, 'Giris', 1, '2025-07-14 13:26:02', 1, NULL, 0, NULL, NULL, 'adet'),
(145, 286, 'Cikis', 1, '2025-07-14 17:04:41', 1, NULL, 1, 42, NULL, 'adet'),
(146, 286, 'Cikis', 1, '2025-07-14 17:04:48', 1, NULL, 1, 42, NULL, 'adet'),
(147, 286, 'Cikis', 1, '2025-07-14 17:04:51', 1, NULL, 1, 42, NULL, 'adet'),
(148, 286, 'Cikis', 1, '2025-07-14 17:12:11', 1, NULL, 1, 42, NULL, 'adet'),
(149, 286, 'Cikis', 1, '2025-07-14 17:12:14', 1, NULL, 1, 42, NULL, 'adet'),
(150, 286, 'Cikis', 1, '2025-07-14 17:13:22', 1, NULL, 1, 42, NULL, 'adet'),
(151, 286, 'Cikis', 1, '2025-07-14 17:13:25', 1, NULL, 1, 42, NULL, 'adet'),
(152, 286, 'Cikis', 1, '2025-07-14 17:13:29', 1, NULL, 1, 42, NULL, 'adet'),
(153, 286, 'Cikis', 1, '2025-07-14 17:16:06', 1, NULL, 1, 42, NULL, 'adet'),
(154, 286, 'Cikis', 1, '2025-07-14 17:16:13', 1, NULL, 1, 42, NULL, 'adet'),
(155, 286, 'Cikis', 1, '2025-07-14 17:16:43', 1, NULL, 1, 42, NULL, 'adet'),
(156, 259, 'Cikis', 1, '2025-07-14 17:25:52', 1, NULL, 1, 42, NULL, 'adet'),
(157, 259, 'Cikis', 1, '2025-07-14 17:29:27', 1, NULL, 1, 42, NULL, 'adet'),
(158, 259, 'Cikis', 1, '2025-07-14 17:37:20', 1, NULL, 1, 42, NULL, 'adet'),
(159, 335, 'Giris', 1, '2025-07-16 08:22:01', 1, NULL, 0, NULL, NULL, 'adet'),
(160, 338, 'Cikis', 1, '2025-07-16 08:41:58', 1, NULL, 1, 42, NULL, 'adet'),
(161, 338, 'Cikis', 1, '2025-07-16 08:43:59', 1, NULL, 1, 42, NULL, 'adet'),
(162, 338, 'Cikis', 1, '2025-07-16 09:01:19', 1, NULL, 1, 42, NULL, 'adet'),
(163, 338, 'Cikis', 1, '2025-07-16 09:02:55', 1, NULL, 1, 42, NULL, 'adet'),
(164, 338, 'Cikis', 1, '2025-07-16 09:05:54', 1, NULL, 1, 42, NULL, 'adet'),
(165, 338, 'Cikis', 1, '2025-07-16 09:07:25', 1, NULL, 1, 42, NULL, 'adet'),
(166, 338, 'Cikis', 1, '2025-07-16 09:07:50', 1, NULL, 1, 42, NULL, 'adet'),
(167, 338, 'Cikis', 1, '2025-07-16 10:16:46', 1, NULL, 2, NULL, NULL, 'adet'),
(168, 338, 'Giris', 1, '2025-07-16 10:51:04', 2, NULL, 0, NULL, NULL, 'adet'),
(169, 336, 'Giris', 1, '2025-07-16 11:30:41', 1, NULL, 0, NULL, NULL, 'adet'),
(170, 338, 'Cikis', 1, '2025-07-16 12:06:30', 1, NULL, 1, 42, NULL, 'adet'),
(171, 335, 'Cikis', 1, '2025-07-16 16:39:17', 1, NULL, 0, NULL, NULL, 'adet'),
(172, 338, 'Cikis', 1, '2025-07-17 09:06:54', 1, NULL, 1, 42, NULL, 'adet'),
(173, 338, 'Cikis', 1, '2025-07-17 09:27:10', 1, NULL, 1, 42, NULL, 'adet'),
(174, 341, 'Giris', 1, '2025-07-17 12:35:09', 1, NULL, 0, NULL, NULL, 'adet'),
(175, 341, 'Giris', 1, '2025-07-17 12:43:00', 1, NULL, 0, NULL, NULL, 'adet'),
(176, 341, 'Giris', 9, '2025-07-17 12:43:35', 1, NULL, 0, NULL, NULL, 'adet'),
(177, 341, 'Cikis', 1, '2025-07-17 12:48:01', 1, NULL, 1, 43, NULL, 'adet'),
(178, 341, 'Cikis', 1, '2025-07-17 12:48:08', 1, NULL, 1, 43, NULL, 'adet'),
(179, 341, 'Cikis', 2, '2025-07-17 12:48:15', 1, NULL, 1, 43, NULL, 'adet'),
(180, 341, 'Cikis', 1, '2025-07-17 13:47:41', 1, NULL, 1, 43, NULL, 'adet'),
(181, 341, 'Giris', 1, '2025-07-17 13:47:50', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(182, 341, 'Cikis', 1, '2025-07-17 13:48:34', 1, NULL, 1, 43, NULL, 'adet'),
(183, 341, 'Cikis', 2, '2025-07-17 13:48:41', 1, NULL, 1, 43, NULL, 'adet'),
(184, 341, 'Cikis', 1, '2025-07-17 13:50:06', 1, NULL, 1, 43, NULL, 'adet'),
(185, 341, 'Cikis', 3, '2025-07-17 13:54:17', 1, NULL, 1, 43, NULL, 'adet'),
(186, 341, 'Giris', 1, '2025-07-17 13:54:23', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(187, 341, 'Giris', 3, '2025-07-17 13:54:26', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(188, 341, 'Cikis', 1, '2025-07-17 14:20:22', 1, NULL, 1, 43, NULL, 'adet'),
(189, 327, 'Cikis', 1, '2025-07-17 14:33:11', 1, NULL, 1, 43, NULL, 'adet'),
(190, 341, 'Cikis', 1, '2025-07-17 14:46:09', 1, NULL, 1, 43, NULL, 'adet'),
(191, 336, 'Cikis', 1, '2025-07-17 14:48:17', 1, NULL, 1, 43, NULL, 'adet'),
(192, 336, 'Cikis', 4, '2025-07-17 14:51:13', 1, NULL, 1, 43, NULL, 'adet'),
(193, 341, 'Giris', 1, '2025-07-17 15:46:57', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(194, 336, 'Giris', 1, '2025-07-17 15:52:18', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(195, 336, 'Giris', 4, '2025-07-17 15:52:20', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(196, 336, 'Giris', 1, '2025-07-17 16:48:24', 1, NULL, 0, NULL, NULL, 'adet'),
(197, 336, 'Giris', 1, '2025-07-17 16:49:06', 1, NULL, 0, NULL, NULL, 'adet'),
(198, 340, 'Giris', 1, '2025-07-17 16:49:34', 1, NULL, 0, NULL, NULL, 'adet'),
(199, 336, 'Giris', 1, '2025-07-17 16:49:41', 1, NULL, 0, NULL, NULL, 'adet'),
(200, 336, 'Giris', 100, '2025-07-17 16:49:51', 1, NULL, 0, NULL, NULL, 'adet'),
(201, 342, 'Giris', 10, '2025-07-17 16:50:29', 1, NULL, 0, NULL, NULL, 'adet'),
(202, 343, 'Giris', 1, '2025-07-17 17:15:04', 1, NULL, 0, NULL, NULL, 'adet'),
(203, 343, 'Giris', 1, '2025-07-17 17:15:16', 1, NULL, 0, NULL, NULL, 'adet'),
(204, 344, 'Giris', 1, '2025-07-17 17:16:20', 1, NULL, 0, NULL, NULL, 'adet'),
(205, 344, 'Cikis', 1, '2025-07-17 17:18:43', 1, NULL, 0, NULL, NULL, 'adet'),
(206, 344, 'Cikis', 1, '2025-07-17 17:23:36', 1, NULL, 0, NULL, NULL, 'adet'),
(207, 336, 'Cikis', 1, '2025-07-17 17:47:28', 1, NULL, 1, 43, NULL, 'adet'),
(208, 336, 'Giris', 1, '2025-07-17 17:47:47', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(209, 261, 'Cikis', 1, '2025-07-18 09:12:28', 1, NULL, 1, 43, NULL, 'adet'),
(210, 261, 'Giris', 1, '2025-07-18 09:14:05', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(211, 327, 'Cikis', 1, '2025-07-18 09:15:20', 1, NULL, 1, 43, NULL, 'adet'),
(212, 327, 'Giris', 1, '2025-07-18 09:19:44', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(213, 261, 'Giris', 1, '2025-07-18 10:20:12', 1, NULL, 0, NULL, NULL, 'adet'),
(214, 262, 'Giris', 1, '2025-07-18 10:26:05', 1, NULL, 0, NULL, NULL, 'adet'),
(215, 262, 'Giris', 1, '2025-07-18 10:28:36', 1, NULL, 0, NULL, NULL, 'adet'),
(216, 262, 'Giris', 1, '2025-07-18 10:35:22', 1, NULL, 0, NULL, NULL, 'adet'),
(217, 316, 'Cikis', 4, '2025-07-18 10:38:16', 1, NULL, 1, 43, NULL, 'adet'),
(218, 316, 'Giris', 4, '2025-07-18 10:38:32', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(219, 316, 'Cikis', 1, '2025-07-18 10:38:36', 1, NULL, 1, 43, NULL, 'adet'),
(220, 316, 'Cikis', 3, '2025-07-18 10:39:02', 1, NULL, 1, 43, NULL, 'adet'),
(221, 316, 'Giris', 3, '2025-07-18 10:39:06', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(222, 316, 'Giris', 1, '2025-07-18 10:39:08', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(223, 316, 'Cikis', 1, '2025-07-18 10:46:53', 1, NULL, 1, 43, NULL, 'adet'),
(224, 316, 'Cikis', 1, '2025-07-18 10:46:54', 1, NULL, 1, 43, NULL, 'adet'),
(225, 261, 'Cikis', 1, '2025-07-18 11:50:43', 1, NULL, 1, 43, NULL, 'adet'),
(226, 261, 'Giris', 1, '2025-07-18 11:50:48', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(227, 261, 'Cikis', 6, '2025-07-18 12:29:00', 1, NULL, 1, 43, NULL, 'adet'),
(228, 327, 'Giris', 1, '2025-07-21 14:58:46', 1, NULL, 0, NULL, NULL, 'adet'),
(229, 327, 'Cikis', 1, '2025-07-21 14:58:50', 1, NULL, 0, NULL, NULL, 'adet'),
(230, 323, 'Giris', 1, '2025-07-21 15:06:36', 1, NULL, 0, NULL, NULL, 'adet'),
(235, 336, 'Giris', 1, '2025-07-21 16:31:26', 1, NULL, 0, NULL, NULL, 'adet'),
(236, 336, 'Giris', 1, '2025-07-21 17:07:39', 1, NULL, 0, NULL, NULL, 'adet'),
(237, 336, 'Giris', 1, '2025-07-21 17:10:56', 1, NULL, 0, NULL, NULL, 'adet'),
(238, 336, 'Giris', 1, '2025-07-21 17:18:47', 1, NULL, 0, NULL, NULL, 'adet'),
(239, 336, 'Giris', 1, '2025-07-21 17:27:09', 1, NULL, 0, NULL, NULL, 'adet'),
(240, 336, 'Giris', 20, '2025-07-21 17:30:16', 1, NULL, 0, NULL, NULL, 'adet'),
(241, 336, 'Giris', 20, '2025-07-21 17:30:53', 1, NULL, 0, NULL, NULL, 'adet'),
(242, 336, 'Giris', 1, '2025-07-22 08:44:33', 1, NULL, 0, NULL, NULL, 'adet'),
(243, 336, 'Giris', 1, '2025-07-22 08:44:43', 1, NULL, 0, NULL, NULL, 'adet'),
(244, 336, 'Cikis', 1, '2025-07-22 09:57:38', 1, NULL, 0, NULL, NULL, 'adet'),
(245, 336, 'Cikis', 1, '2025-07-22 09:58:47', 1, NULL, 0, NULL, NULL, 'adet'),
(246, 336, 'Cikis', 1, '2025-07-22 09:59:41', 1, NULL, 0, NULL, NULL, 'adet'),
(247, 336, 'Cikis', 1, '2025-07-22 10:00:18', 1, NULL, 2, NULL, NULL, 'adet'),
(248, 327, 'Cikis', 1, '2025-07-22 10:15:36', 1, NULL, 0, NULL, 7, 'adet'),
(249, 327, 'Cikis', 1, '2025-07-22 10:15:55', 1, NULL, 0, NULL, 8, 'adet'),
(250, 327, 'Cikis', 1, '2025-07-22 10:16:16', 1, NULL, 0, NULL, 7, 'adet'),
(251, 327, 'Cikis', 97, '2025-07-22 10:21:10', 1, NULL, 0, NULL, NULL, 'adet'),
(252, 327, 'Giris', 79, '2025-07-22 10:45:14', 1, NULL, 0, NULL, NULL, 'adet'),
(253, 327, 'Giris', 5, '2025-07-22 10:45:44', 1, NULL, 0, NULL, NULL, 'adet'),
(254, 336, 'Cikis', 1, '2025-07-22 11:01:31', 1, NULL, 0, NULL, 9, 'adet'),
(255, 336, 'Cikis', 1, '2025-07-22 11:01:38', 1, NULL, 0, NULL, 8, 'adet'),
(256, 336, 'Cikis', 1, '2025-07-22 11:01:43', 1, NULL, 0, NULL, 7, 'adet'),
(257, 336, 'Cikis', 1, '2025-07-22 11:01:50', 1, NULL, 0, NULL, 7, 'adet'),
(258, 336, 'Cikis', 1, '2025-07-22 11:01:53', 1, NULL, 0, NULL, 7, 'adet'),
(259, 336, 'Cikis', 1, '2025-07-22 11:01:58', 1, NULL, 0, NULL, 7, 'adet'),
(260, 327, 'Cikis', 1, '2025-07-22 11:24:44', 1, NULL, 1, 43, NULL, 'adet'),
(261, 327, 'Cikis', 1, '2025-07-22 11:24:49', 1, NULL, 1, 43, NULL, 'adet'),
(262, 327, 'Cikis', 1, '2025-07-22 11:25:20', 1, NULL, 1, 43, NULL, 'adet'),
(263, 327, 'Cikis', 1, '2025-07-22 11:32:04', 1, NULL, 1, 43, NULL, 'adet'),
(264, 327, 'Cikis', 1, '2025-07-22 11:57:08', 1, NULL, 1, 43, NULL, 'adet'),
(265, 327, 'Cikis', 1, '2025-07-22 12:01:53', 1, NULL, 1, 43, NULL, 'adet'),
(266, 327, 'Cikis', 1, '2025-07-22 12:02:08', 1, NULL, 1, 43, NULL, 'adet'),
(267, 327, 'Giris', 1, '2025-07-22 12:08:13', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(268, 327, 'Giris', 1, '2025-07-22 12:08:15', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(269, 327, 'Cikis', 1, '2025-07-22 12:27:15', 1, NULL, 1, 43, NULL, 'adet'),
(270, 327, 'Cikis', 1, '2025-07-22 12:27:20', 1, NULL, 1, 43, NULL, 'adet'),
(271, 334, 'Giris', 1, '2025-07-22 12:54:15', 1, NULL, 0, NULL, NULL, 'adet'),
(272, 336, 'Giris', 5, '2025-07-22 13:12:39', 1, NULL, 0, NULL, NULL, 'adet'),
(273, 336, 'Giris', 1, '2025-07-22 13:14:11', 1, NULL, 0, NULL, NULL, 'adet'),
(274, 336, 'Giris', 1, '2025-07-22 13:14:15', 1, NULL, 0, NULL, NULL, 'adet'),
(275, 336, 'Giris', 1, '2025-07-22 13:14:40', 1, NULL, 0, NULL, NULL, 'adet'),
(276, 259, 'Giris', 1, '2025-07-22 13:15:08', 1, NULL, 0, NULL, NULL, 'adet'),
(287, 259, 'Giris', 1, '2025-07-22 15:01:27', 1, NULL, 0, NULL, NULL, 'adet'),
(288, 352, 'Giris', 1, '2025-07-22 15:19:38', 1, NULL, 0, NULL, NULL, 'adet'),
(289, 336, 'Giris', 1, '2025-07-22 15:24:27', 1, NULL, 0, NULL, NULL, 'adet'),
(290, 259, 'Giris', 1, '2025-07-22 15:32:40', 1, NULL, 0, NULL, NULL, 'adet'),
(291, 277, 'Giris', 1, '2025-07-22 15:40:48', 1, NULL, 0, NULL, NULL, 'adet'),
(292, 259, 'Giris', 1, '2025-07-22 15:54:01', 1, NULL, 0, NULL, NULL, 'adet'),
(293, 331, 'Giris', 1, '2025-07-22 15:57:46', 1, NULL, 0, NULL, NULL, 'adet'),
(294, 265, 'Giris', 1, '2025-07-22 16:14:52', 1, NULL, 0, NULL, NULL, 'adet'),
(295, 353, 'Giris', 1, '2025-07-22 16:15:54', 1, NULL, 0, NULL, NULL, 'adet'),
(296, 353, 'Giris', 1, '2025-07-22 16:19:29', 1, NULL, 0, NULL, NULL, 'cm'),
(297, 327, 'Giris', 1, '2025-07-22 16:27:57', 1, NULL, 0, NULL, NULL, 'adet'),
(298, 327, 'Giris', 1, '2025-07-22 16:31:18', 1, NULL, 0, NULL, NULL, 'adet'),
(299, 259, 'Giris', 1, '2025-07-22 16:40:20', 1, NULL, 0, NULL, NULL, 'adet'),
(300, 327, 'Giris', 1, '2025-07-22 17:02:36', 1, NULL, 0, NULL, 8, 'adet'),
(301, 327, 'Cikis', 1, '2025-07-22 17:04:32', 1, NULL, 0, NULL, 8, 'adet'),
(302, 327, 'Giris', 1, '2025-07-22 17:18:34', 1, NULL, 0, NULL, NULL, 'adet'),
(303, 327, 'Giris', 5, '2025-07-22 17:38:41', 1, NULL, 0, NULL, 8, 'adet'),
(304, 327, 'Cikis', 1, '2025-07-23 08:56:31', 1, NULL, 1, 43, NULL, 'adet'),
(305, 327, 'Cikis', 1, '2025-07-23 09:12:00', 1, 'Çıkış Proje', 1, 43, 8, 'adet'),
(306, 327, 'Cikis', 2, '2025-07-23 09:13:07', 1, 'Çıkış Proje', 1, 43, 8, 'adet'),
(307, 327, 'Cikis', 1, '2025-07-23 09:22:11', 1, 'Çıkış Proje', 1, 43, 8, 'adet'),
(308, 327, 'Giris', 1, '2025-07-23 09:22:57', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(309, 327, 'Giris', 2, '2025-07-23 09:23:28', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(310, 327, 'Cikis', 3, '2025-07-23 09:26:42', 1, 'Çıkış Proje', 1, 43, 8, 'adet'),
(311, 327, 'Cikis', 1, '2025-07-23 09:32:21', 1, 'Çıkış Proje', 1, 43, 8, 'adet'),
(312, 327, 'Cikis', 1, '2025-07-23 09:34:37', 1, 'Çıkış Proje', 1, 43, 8, 'adet'),
(313, 327, 'Giris', 1, '2025-07-23 09:34:44', 1, 'İşlem geri alındı', 1, 43, NULL, 'adet'),
(314, 327, 'Cikis', 1, '2025-07-23 09:42:19', 1, 'Proje için alındı', 1, 43, 8, 'adet'),
(315, 327, 'Cikis', 1, '2025-07-23 09:42:24', 1, 'Proje için alındı', 1, 43, 8, 'adet'),
(316, 327, 'Cikis', 1, '2025-07-23 09:42:28', 1, 'Proje için alındı', 1, 43, 8, 'adet'),
(317, 327, 'Cikis', 1, '2025-07-23 09:42:31', 1, 'Proje için alındı', 1, 43, 8, 'adet'),
(318, 327, 'Cikis', 1, '2025-07-23 09:42:36', 1, 'Proje için alındı', 1, 43, 8, 'adet'),
(319, 327, 'Cikis', 1, '2025-07-23 09:44:15', 1, NULL, 2, NULL, 8, 'adet'),
(320, 327, 'Cikis', 1, '2025-07-23 10:00:33', 1, 'firma aldı', 0, NULL, 8, 'adet'),
(321, 327, 'Cikis', 5, '2025-07-23 10:01:05', 1, 'firma aldı', 0, NULL, 8, 'adet');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `depo_konum`
--
ALTER TABLE `depo_konum`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `kat` (`harf`,`numara`);

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
-- Tablo için indeksler `urun_guncelleme_log`
--
ALTER TABLE `urun_guncelleme_log`
  ADD PRIMARY KEY (`log_id`),
  ADD KEY `urun_id` (`urun_id`),
  ADD KEY `degistiren_id` (`degistiren_id`);

--
-- Tablo için indeksler `urun_hareketleri`
--
ALTER TABLE `urun_hareketleri`
  ADD PRIMARY KEY (`id`),
  ADD KEY `urun_id` (`urun_id`),
  ADD KEY `kullanici_id` (`kullanici_id`),
  ADD KEY `islem_turu_id` (`islem_turu_id`),
  ADD KEY `fk_urun_hareketleri_proje` (`proje_id`),
  ADD KEY `fk_urun_hareketleri_depo_konum` (`depo_konum_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `depo_konum`
--
ALTER TABLE `depo_konum`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Tablo için AUTO_INCREMENT değeri `kullanicilar`
--
ALTER TABLE `kullanicilar`
  MODIFY `kullanici_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Tablo için AUTO_INCREMENT değeri `projeler`
--
ALTER TABLE `projeler`
  MODIFY `proje_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=46;

--
-- Tablo için AUTO_INCREMENT değeri `proje_hareketleri`
--
ALTER TABLE `proje_hareketleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=99;

--
-- Tablo için AUTO_INCREMENT değeri `proje_urunleri`
--
ALTER TABLE `proje_urunleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1439;

--
-- Tablo için AUTO_INCREMENT değeri `urunler`
--
ALTER TABLE `urunler`
  MODIFY `urun_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=354;

--
-- Tablo için AUTO_INCREMENT değeri `urun_guncelleme_log`
--
ALTER TABLE `urun_guncelleme_log`
  MODIFY `log_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tablo için AUTO_INCREMENT değeri `urun_hareketleri`
--
ALTER TABLE `urun_hareketleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=322;

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
-- Tablo kısıtlamaları `urun_guncelleme_log`
--
ALTER TABLE `urun_guncelleme_log`
  ADD CONSTRAINT `urun_guncelleme_log_ibfk_1` FOREIGN KEY (`urun_id`) REFERENCES `urunler` (`urun_id`),
  ADD CONSTRAINT `urun_guncelleme_log_ibfk_2` FOREIGN KEY (`degistiren_id`) REFERENCES `kullanicilar` (`kullanici_id`);

--
-- Tablo kısıtlamaları `urun_hareketleri`
--
ALTER TABLE `urun_hareketleri`
  ADD CONSTRAINT `fk_urun_hareketleri_depo_konum` FOREIGN KEY (`depo_konum_id`) REFERENCES `depo_konum` (`id`) ON DELETE SET NULL,
  ADD CONSTRAINT `fk_urun_hareketleri_proje` FOREIGN KEY (`proje_id`) REFERENCES `projeler` (`proje_id`),
  ADD CONSTRAINT `urun_hareketleri_ibfk_1` FOREIGN KEY (`urun_id`) REFERENCES `urunler` (`urun_id`),
  ADD CONSTRAINT `urun_hareketleri_ibfk_2` FOREIGN KEY (`kullanici_id`) REFERENCES `kullanicilar` (`kullanici_id`),
  ADD CONSTRAINT `urun_hareketleri_ibfk_3` FOREIGN KEY (`islem_turu_id`) REFERENCES `islem_turu` (`islem_turu_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
