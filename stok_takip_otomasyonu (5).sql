-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 10 Tem 2025, 15:08:40
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

--
-- Tablo döküm verisi `depo_konum`
--

INSERT INTO `depo_konum` (`id`, `kat`, `konum`) VALUES
(1, '0', 'A1'),
(2, '0', 'A2'),
(3, '0', 'A3'),
(4, '0', 'A4'),
(5, '0', 'B1'),
(6, '0', 'B2');

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
(1, 'admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 1, 'Sistem Yöneticisi', 1, '2025-07-04 13:59:18'),
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
  `kayit_tarihi` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `projeler`
--

INSERT INTO `projeler` (`proje_id`, `proje_kodu`, `proje_tanimi`, `aktif`, `kayit_tarihi`) VALUES
(1, 'E956', 'E956 VANA OTOMASYONU', 1, '2025-07-05 14:27:29'),
(2, 'E800', 'E800 VANA OTOMASYONU', 1, '2025-07-07 09:02:21'),
(11, 'E444', 'E444 VANA OTOMASYONU', 0, '2025-07-09 16:31:38'),
(14, 'A123', 'GHBK', 1, '2025-07-10 11:33:10');

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
(2, 14, 5, 5, 1, '2025-07-10 14:21:22'),
(7, 14, 5, 1, 1, '2025-07-10 14:44:05');

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
(379, 14, 5, 6, '2025-07-10 13:21:32', 1),
(380, 14, 13, 5, '2025-07-10 14:24:10', 1),
(381, 14, 11, 10, '2025-07-10 14:24:43', 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urunler`
--

CREATE TABLE `urunler` (
  `urun_id` int(11) NOT NULL,
  `urun_adi` varchar(100) NOT NULL,
  `urun_kodu` varchar(50) NOT NULL,
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
(1, 'Klemens', '105698', NULL, '979797', 'LEU', '123456', 115, NULL, '2025-07-04 15:06:18'),
(2, '', '', NULL, '0526378', NULL, NULL, 35, NULL, '2025-07-04 16:48:05'),
(4, 'YENİ ÜRÜN', '562', NULL, '564', '', '', 10, NULL, '2025-07-05 15:04:03'),
(5, 'Klemens', '123456', NULL, '123', 'Leuze', '25987', 272, NULL, '2025-07-05 15:43:39'),
(11, 'Vida', '987654321', NULL, '999', 'Leuze', '23', 0, NULL, '2025-07-07 12:08:05'),
(13, 'Siemens kablo', '65456461', NULL, '12345', 'Siemens', '25648416', 5, NULL, '2025-07-08 16:45:17'),
(14, 'YENİ ÜRÜN', '888', NULL, '888', '', '', 30, NULL, '2025-07-09 10:50:57'),
(183, 'Tek katlı tepe lambası + Buzzer', 'SNT-7024-SB1', 'Tek katlı tepe lambası + Buzzer', NULL, 'Mucco', NULL, 0, NULL, '2025-07-09 16:31:38'),
(184, 'İki elli şalt cihazı', '774350', 'İki elli şalt cihazı', NULL, 'PILZ', NULL, 0, NULL, '2025-07-09 16:31:38'),
(185, 'Terminal bloğu için uç braketi', '3022276', 'Terminal bloğu için uç braketi', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(186, 'Klemens dizisi etiket taşıyıcı', '0811969', 'Klemens dizisi etiket taşıyıcı', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(187, 'Geçişli terminal bloğu', '3211757', 'Geçişli terminal bloğu', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(188, 'Topraklama modüler terminal bloğu', '3211766', 'Topraklama modüler terminal bloğu', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(189, 'Terminal bloğu için uç ve bölme plakası', '3030420', 'Terminal bloğu için uç ve bölme plakası', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(190, 'Topraklama modüler terminal bloğu', '3209536', 'Topraklama modüler terminal bloğu', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(191, 'Terminal bloğu için uç ve bölme plakası', '3030417', 'Terminal bloğu için uç ve bölme plakası', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(192, 'Geçişli terminal bloğu', '3209523', 'Geçişli terminal bloğu', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(193, 'Geçmeli köprü', '3030174', 'Geçmeli köprü', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(194, 'Geçişli terminal bloğu', '3209512', 'Geçişli terminal bloğu', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(195, 'Geçmeli köprü', '3030161', 'Geçmeli köprü', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(196, 'Sigortalı modüler klemens', '3036547', 'Sigortalı modüler klemens', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(197, 'Geçişli terminal bloğu', '3209510', 'Geçişli terminal bloğu', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(198, 'Röle Modülü', '2900299', 'Röle Modülü', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(199, 'Çift seviyeli terminal bloğu', '3210567', 'Çift seviyeli terminal bloğu', NULL, 'PXC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(200, 'FANLI FILTRE 108 m3/h 162X162X65mm', 'FULL1500', 'FANLI FILTRE 108 m3/h 162X162X65mm', NULL, 'QUICK', NULL, 0, NULL, '2025-07-09 16:31:38'),
(201, 'Panel Filtre (162x162x24mm) KESİM=125x125', 'FIL1500', 'Panel Filtre (162x162x24mm) KESİM=125x125', NULL, 'QUICK', NULL, 0, NULL, '2025-07-09 16:31:38'),
(202, 'Minyatür devre kesici iC60N, 3P, 16A, C', 'A9F74316', 'Minyatür devre kesici iC60N, 3P, 16A, C', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(203, 'TeSys Vario - kapı üzerinde acil durdurma şalteri ayırıcısı', 'VCF01', 'TeSys Vario - kapı üzerinde acil durdurma şalteri ayırıcısı', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(204, 'Minyatür devre kesici iC60N, 3P, 2A, C', 'A9F74302', 'Minyatür devre kesici iC60N, 3P, 2A, C', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(205, 'Minyatür devre kesici iC60N, 1P, 4A, C', 'A9F74104', 'Minyatür devre kesici iC60N, 1P, 4A, C', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(206, 'Beyaz komple pilot lambası Ø22 entegre LED\'li düz lens 230...240V', 'XB4BVM1', 'Beyaz komple pilot lambası Ø22 entegre LED\'li düz lens 230...240V', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(207, 'Minyatür devre kesici iC60N, 1P, 10A, C', 'A9F74110', 'Minyatür devre kesici iC60N, 1P, 10A, C', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(208, 'TeSys K kontaktör - 3P(3 NA) - AC-3 - <= 440 V 6 A - 24 V DC bobin', 'LP1K0610BD', 'TeSys K kontaktör - 3P(3 NA) - AC-3 - <= 440 V 6 A - 24 V DC bobin', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(209, 'Kırmızı Ø40 Acil durdurma, kapatma Ø22 mandallı dönüş serbest bırakma 1NK 600VAC', 'XB4BS8442', 'Kırmızı Ø40 Acil durdurma, kapatma Ø22 mandallı dönüş serbest bırakma 1NK 600VAC', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(210, 'Siyah Ø40 mantar Buton Ø22 yaylı dönüş 1NA', 'XB4BC21', 'Siyah Ø40 mantar Buton Ø22 yaylı dönüş 1NA', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(211, 'Harmony XB5 1NK kontağı', 'ZBE102', 'Harmony XB5 1NK kontağı', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(212, 'Kontaktör TeSys LC1-D - 3P - AC-3 440V 9 A, Bobin 24 V DC', 'LC1D09BD', 'Kontaktör TeSys LC1-D - 3P - AC-3 440V 9 A, Bobin 24 V DC', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(213, 'Termik Manyetik Motorlu Devre Kesici TeSys GV2ME - 3P - 1...1.6 A', 'GV2ME06', 'Termik Manyetik Motorlu Devre Kesici TeSys GV2ME - 3P - 1...1.6 A', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(214, 'TeSys GVAE11 - yardımcı kontak - 1 NA + 1 NK', 'GVAE11', 'TeSys GVAE11 - yardımcı kontak - 1 NA + 1 NK', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(215, 'Minyatür devre kesici iC60N, 1P, 16A, C', 'A9F74116', 'Minyatür devre kesici iC60N, 1P, 16A, C', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(216, 'Siyah seçim anahtarı Ø22 2 konumlu sabit 1NA 600V', 'XB4BD21', 'Siyah seçim anahtarı Ø22 2 konumlu sabit 1NA 600V', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(217, 'Yeşil sıva altı komple ışıklı buton Ø22 yaylı dönüş 1NA+1NK 24V', 'XB4BW33B5', 'Yeşil sıva altı komple ışıklı buton Ø22 yaylı dönüş 1NA+1NK 24V', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(218, 'Kırmızı gömme komple buton Ø22 yay geri dönüşlü 1NC \"işaretsiz\"', 'XB4BA42', 'Kırmızı gömme komple buton Ø22 yay geri dönüşlü 1NC \"işaretsiz\"', NULL, 'SE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(219, 'Manifold', 'SS5Y3-10L13-09B', 'Manifold', NULL, 'SMC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(220, 'SY3000, 5 Portlu Solenoid Valf, Tüm Tipler - Yeni Stil', 'SY3200-5U1', 'SY3000, 5 Portlu Solenoid Valf, Tüm Tipler - Yeni Stil', NULL, 'SMC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(221, 'KÖRLEME PLAKASI TAKIMI', 'SY30M-26-1A', 'KÖRLEME PLAKASI TAKIMI', NULL, 'SMC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(222, 'Manifold', 'SS5Y3-10L13-08B', 'Manifold', NULL, 'SMC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(223, 'Manifold', 'SS5Y3-10L13-10B', 'Manifold', NULL, 'SMC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(224, 'Manifold', 'SS5Y3-10L13-12B', 'Manifold', NULL, 'SMC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(225, '', 'SY30M-14-4A-1-3', '', NULL, 'SMC', NULL, 0, NULL, '2025-07-09 16:31:38'),
(226, 'Güç ve kontrol kabloları 0,6/1,0 kV', '5G4 YSLY-JB', 'Güç ve kontrol kabloları 0,6/1,0 kV', NULL, 'TSE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(227, 'Güç ve kontrol kabloları', '7G0,75 YSLY-JZ', 'Güç ve kontrol kabloları', NULL, 'TSE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(228, 'Güç ve kontrol kabloları', '18G0,75 YSLY-JZ', 'Güç ve kontrol kabloları', NULL, 'TSE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(229, 'Güç ve kontrol kabloları 0,6/1,0 kV', '4G2,5 YSLY-JB', 'Güç ve kontrol kabloları 0,6/1,0 kV', NULL, 'TSE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(230, 'Güç ve kontrol kabloları', '3G0,75 YSLY-JZ', 'Güç ve kontrol kabloları', NULL, 'TSE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(231, 'Güç ve kontrol kabloları', '25G0,5 YSLY-JZ', 'Güç ve kontrol kabloları', NULL, 'TSE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(232, 'Güç ve kontrol kabloları 0,6/1,0 kV', '3G1,5 YSLY-JB', 'Güç ve kontrol kabloları 0,6/1,0 kV', NULL, 'TSE', NULL, 0, NULL, '2025-07-09 16:31:38'),
(233, '220VAC Led armatür. Soketi ve 1 metre kablosu dahil.', 'TLPA-10W', '220VAC Led armatür. Soketi ve 1 metre kablosu dahil.', NULL, 'Trio', NULL, 0, NULL, '2025-07-09 16:31:38'),
(234, 'RAY TİPİ PRİZ 16A 250V', 'VSR-G16', 'RAY TİPİ PRİZ 16A 250V', NULL, 'VIKO', NULL, 0, NULL, '2025-07-09 16:31:38'),
(235, 'Cisimden Yansımalı Sensör Arka Fon Bastırmalı', 'P1KH006', 'Cisimden Yansımalı Sensör Arka Fon Bastırmalı', NULL, 'WGL', NULL, 0, NULL, '2025-07-09 16:31:38'),
(236, 'İndüktif sensör arttırılmış anahtarlama mesafeli', 'I12H006', 'İndüktif sensör arttırılmış anahtarlama mesafeli', NULL, 'WGL', NULL, 0, NULL, '2025-07-09 16:31:38'),
(237, 'Cisimden Yansımalı Sensör', 'U1KT001', 'Cisimden Yansımalı Sensör', NULL, 'WGL', NULL, 0, NULL, '2025-07-09 16:31:38'),
(238, '4 Gerilim girişi/Akım girişi', 'AS04AD-A', '4 Gerilim girişi/Akım girişi', NULL, 'DEL', NULL, 0, NULL, '2025-07-10 11:33:10'),
(239, 'AS200 PLC - 16DI / 12DO PNP, Dahili Ethernet / CAN', 'AS228P-A', 'AS200 PLC - 16DI / 12DO PNP, Dahili Ethernet / CAN', NULL, 'DEL', NULL, 0, NULL, '2025-07-10 11:33:10'),
(240, 'AS16AP11P-A ,8D/8P Plc Ek Dijital Modül', 'AS16AP11P-A', 'AS16AP11P-A ,8D/8P Plc Ek Dijital Modül', NULL, 'DEL', NULL, 0, NULL, '2025-07-10 11:33:10'),
(241, 'Endüstriyel Ethernet DIACloud Bulut Yönlendiriciler', 'DX-2300LN-WW', 'Endüstriyel Ethernet DIACloud Bulut Yönlendiriciler', NULL, 'DEL', NULL, 0, NULL, '2025-07-10 11:33:10'),
(242, 'A2 Servo Sürücü - 1000W', 'ASD-A2-1021-M', 'A2 Servo Sürücü - 1000W', NULL, 'DEL', NULL, 0, NULL, '2025-07-10 11:33:10'),
(243, 'A2 Servo Sürücü - 400 Watt', 'ASD-A2-0421-M', 'A2 Servo Sürücü - 400 Watt', NULL, 'DEL', NULL, 0, NULL, '2025-07-10 11:33:10'),
(244, 'Pano Soğutma Termostat\'ı 0-70°C Ray Tipi - Emas 10A 230V AC', 'PTM111', 'Pano Soğutma Termostat\'ı 0-70°C Ray Tipi - Emas 10A 230V AC', NULL, 'EMAS', NULL, 0, NULL, '2025-07-10 11:33:10'),
(245, 'Pimli Plastik Kapı Switch - NC contact type', 'BS1010', 'Pimli Plastik Kapı Switch - NC contact type', NULL, 'EMAS', NULL, 0, NULL, '2025-07-10 11:33:10'),
(246, 'Vibrasyon Kontrol Cihazı', 'EPAC3-W-F', 'Vibrasyon Kontrol Cihazı', NULL, 'ENDA', NULL, 0, NULL, '2025-07-10 11:33:10'),
(247, 'Faz yokluğu, Faz sırası hatası, 1 N/O kontak DIN1 Ray Montaj', 'MKS-03', 'Faz yokluğu, Faz sırası hatası, 1 N/O kontak DIN1 Ray Montaj', NULL, 'ENTES', NULL, 0, NULL, '2025-07-10 11:33:10'),
(248, 'HMI 10” TFT, 1024x600, Dirençli dokunmatik, 4 GB Flash bellek, 1x Ethernet, JMobile çalışma zamanı', 'ESMA10U301', 'HMI 10” TFT, 1024x600, Dirençli dokunmatik, 4 GB Flash bellek, 1x Ethernet, JMobile çalışma zamanı', NULL, 'EXOR', NULL, 0, NULL, '2025-07-10 11:33:10'),
(249, 'Transistör Çıkış Kartı 8\'li', 'GT8-V11', 'Transistör Çıkış Kartı 8\'li', NULL, 'GEM', NULL, 0, NULL, '2025-07-10 11:33:10'),
(250, 'Bağlantı kablosu', '50130832', 'Bağlantı kablosu', NULL, 'LEU', NULL, 0, NULL, '2025-07-10 11:33:10'),
(251, 'Bağlantı kablosu', '50130690', 'Bağlantı kablosu', NULL, 'LEU', NULL, 0, NULL, '2025-07-10 11:33:10'),
(252, 'EXACT12, 8XM12, 5-KUTUPLU, KAPAK, FIŞ. VİDA TERM.', '8000-88550-0000000', 'EXACT12, 8XM12, 5-KUTUPLU, KAPAK, FIŞ. VİDA TERM.', NULL, 'MURR', NULL, 0, NULL, '2025-07-10 11:33:10'),
(253, 'Sensör aktüatör adaptörü', '7000-41201-0000000', 'Sensör aktüatör adaptörü', NULL, 'MURR', NULL, 0, NULL, '2025-07-10 11:33:10'),
(254, 'Dairesel konektör (saha montajı için)', '7000-08601-0000000', 'Dairesel konektör (saha montajı için)', NULL, 'MURR', NULL, 0, NULL, '2025-07-10 11:33:10'),
(255, 'Güç kaynağı 24V 10A 240W 24~28 V', 'NDR-240-24', 'Güç kaynağı 24V 10A 240W 24~28 V', NULL, 'MW', NULL, 0, NULL, '2025-07-10 11:33:10');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun_depo_konum`
--

CREATE TABLE `urun_depo_konum` (
  `urun_id` int(11) NOT NULL,
  `depo_konum_id` int(11) NOT NULL,
  `miktar` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `urun_depo_konum`
--

INSERT INTO `urun_depo_konum` (`urun_id`, `depo_konum_id`, `miktar`) VALUES
(1, 1, 30),
(1, 2, 45),
(5, 1, 100),
(5, 2, 45),
(5, 3, 5),
(5, 5, 120),
(5, 6, 2),
(13, 1, 3),
(13, 4, 2);

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
(2, 2, 'Giris', 10, '2025-07-04 17:22:02', 1, '', 0, NULL),
(35, 11, 'Giris', 35, '2025-07-07 12:08:05', 1, '', 0, NULL),
(45, 13, 'Giris', 15, '2025-07-08 16:45:17', 1, '', 0, NULL),
(46, 13, 'Cikis', 10, '2025-07-08 16:45:59', 1, '', 0, NULL),
(48, 14, 'Giris', 30, '2025-07-09 10:50:57', 1, '', 0, NULL),
(53, 1, 'Giris', 20, '2025-07-09 13:15:14', 1, '', 0, NULL),
(54, 1, 'Giris', 20, '2025-07-09 13:15:31', 1, '', 0, NULL),
(56, 5, 'Cikis', 20, '2025-07-09 17:53:51', 1, 'E444 İÇN ALINDI', 0, NULL),
(57, 5, 'Giris', 10, '2025-07-10 08:28:56', 1, '', 1, NULL),
(58, 5, 'Giris', 20, '2025-07-10 13:21:32', 1, '', 1, NULL),
(59, 5, 'Cikis', 2, '2025-07-10 13:22:05', 1, ' GHBK', 1, NULL),
(60, 5, 'Cikis', 2, '2025-07-10 13:32:40', 1, ' GHBK', 1, NULL),
(61, 5, 'Cikis', 10, '2025-07-10 13:46:14', 1, ' GHBK', 1, NULL),
(62, 13, 'Giris', 5, '2025-07-10 14:24:10', 1, '', 1, NULL),
(63, 11, 'Giris', 10, '2025-07-10 14:24:43', 1, '', 1, NULL);

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
  ADD UNIQUE KEY `proje_kodu` (`proje_kodu`);

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
  MODIFY `kullanici_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `projeler`
--
ALTER TABLE `projeler`
  MODIFY `proje_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Tablo için AUTO_INCREMENT değeri `proje_hareketleri`
--
ALTER TABLE `proje_hareketleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Tablo için AUTO_INCREMENT değeri `proje_urunleri`
--
ALTER TABLE `proje_urunleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=382;

--
-- Tablo için AUTO_INCREMENT değeri `urunler`
--
ALTER TABLE `urunler`
  MODIFY `urun_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=256;

--
-- Tablo için AUTO_INCREMENT değeri `urun_hareketleri`
--
ALTER TABLE `urun_hareketleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=64;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

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
