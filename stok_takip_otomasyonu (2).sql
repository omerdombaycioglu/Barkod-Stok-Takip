-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 11 Tem 2025, 16:49:11
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
(2, 'kullanici', '123', 2, 'Standart Kullanıcı', 0, '2025-07-04 13:59:18');

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
(16, 'E459', 'E459 VANA OTOMASYONU', 1, '2025-07-11 16:38:45', 1),
(22, 'E447', 'E444 BARDAK MAKİNESİ', 1, '2025-07-11 17:04:59', 1),
(23, 'E646', 'E646 VANA OTOMASYONU', 1, '2025-07-11 17:10:15', 1),
(24, 'E333', 'E333 VANA OTOMASYONU', 1, '2025-07-11 17:12:59', 1),
(25, 'E222', 'E222 VANA OTOMASYONU', 1, '2025-07-11 17:20:18', 1),
(26, 'E111', 'E111 VANA OTOMASYONU', 1, '2025-07-11 17:21:41', 1),
(27, 'E199', 'E199 VANA OTOMASYONU', 1, '2025-07-11 17:29:58', 1),
(28, 'E2099', 'E299 VANA OTOMASYONU', 1, '2025-07-11 17:30:18', 1),
(29, 'E456', 'E456 VANA OTOMASYONU', 1, '2025-07-11 17:32:12', 1),
(30, 'E765', 'E567 VANA OTOMASYONU', 1, '2025-07-11 17:35:48', 1),
(31, '1561', '546464', 1, '2025-07-11 17:38:09', 1),
(32, 'E234234234', '14234234523', 1, '2025-07-11 17:46:32', 1);

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
(710, 24, 290, 12, '2025-07-11 17:13:04', 1),
(711, 24, 291, 45, '2025-07-11 17:13:04', 1),
(712, 24, 292, 1, '2025-07-11 17:13:04', 1),
(713, 24, 293, 95, '2025-07-11 17:13:04', 1),
(714, 24, 294, 1, '2025-07-11 17:13:04', 1),
(715, 24, 295, 1, '2025-07-11 17:13:04', 1),
(716, 24, 296, 1, '2025-07-11 17:13:04', 1),
(717, 24, 297, 1, '2025-07-11 17:13:04', 1),
(718, 24, 298, 1, '2025-07-11 17:13:04', 1),
(719, 24, 299, 5, '2025-07-11 17:13:04', 1),
(720, 24, 300, 3, '2025-07-11 17:13:04', 1),
(721, 24, 301, 7, '2025-07-11 17:13:04', 1),
(722, 24, 302, 1, '2025-07-11 17:13:04', 1),
(723, 24, 303, 2, '2025-07-11 17:13:04', 1),
(724, 24, 304, 2, '2025-07-11 17:13:04', 1),
(725, 24, 305, 2, '2025-07-11 17:13:04', 1),
(726, 24, 306, 1, '2025-07-11 17:13:04', 1),
(727, 24, 307, 1, '2025-07-11 17:13:04', 1),
(728, 24, 308, 1, '2025-07-11 17:13:04', 1),
(729, 24, 309, 2, '2025-07-11 17:13:04', 1),
(730, 24, 310, 1, '2025-07-11 17:13:04', 1),
(731, 24, 311, 1, '2025-07-11 17:13:04', 1),
(732, 24, 312, 1, '2025-07-11 17:13:04', 1),
(733, 24, 313, 1, '2025-07-11 17:13:04', 1),
(734, 24, 314, 35, '2025-07-11 17:13:04', 1),
(735, 24, 315, 4, '2025-07-11 17:13:04', 1),
(736, 24, 316, 1, '2025-07-11 17:13:04', 1),
(737, 24, 317, 1, '2025-07-11 17:13:04', 1),
(738, 24, 318, 1, '2025-07-11 17:13:04', 1),
(739, 24, 319, 4, '2025-07-11 17:13:04', 1),
(740, 24, 320, 1, '2025-07-11 17:13:04', 1),
(741, 24, 321, 3, '2025-07-11 17:13:04', 1),
(742, 24, 322, 1, '2025-07-11 17:13:04', 1),
(743, 24, 323, 1, '2025-07-11 17:13:04', 1),
(744, 24, 324, 5, '2025-07-11 17:13:04', 1),
(745, 24, 325, 5, '2025-07-11 17:13:04', 1),
(746, 24, 326, 2, '2025-07-11 17:13:04', 1),
(747, 24, 327, 1, '2025-07-11 17:13:04', 1),
(748, 24, 328, 1, '2025-07-11 17:13:04', 1),
(749, 24, 329, 6, '2025-07-11 17:13:04', 1),
(750, 24, 330, 5, '2025-07-11 17:13:04', 1),
(751, 24, 331, 1, '2025-07-11 17:13:04', 1),
(752, 25, 259, 1, '2025-07-11 17:20:28', 1),
(753, 25, 260, 1, '2025-07-11 17:20:28', 1),
(754, 25, 261, 14, '2025-07-11 17:20:28', 1),
(755, 25, 262, 1, '2025-07-11 17:20:28', 1),
(756, 25, 263, 2, '2025-07-11 17:20:28', 1),
(757, 25, 264, 3, '2025-07-11 17:20:28', 1),
(758, 25, 265, 1, '2025-07-11 17:20:28', 1),
(759, 25, 266, 1, '2025-07-11 17:20:28', 1),
(760, 25, 267, 2, '2025-07-11 17:20:28', 1),
(761, 25, 268, 1, '2025-07-11 17:20:28', 1),
(762, 25, 269, 1, '2025-07-11 17:20:28', 1),
(763, 25, 270, 12, '2025-07-11 17:20:28', 1),
(764, 25, 271, 73, '2025-07-11 17:20:28', 1),
(765, 25, 272, 10, '2025-07-11 17:20:28', 1),
(766, 25, 273, 5, '2025-07-11 17:20:28', 1),
(767, 25, 274, 39, '2025-07-11 17:20:28', 1),
(768, 25, 275, 146, '2025-07-11 17:20:28', 1),
(769, 25, 276, 1, '2025-07-11 17:20:28', 1),
(770, 25, 277, 1, '2025-07-11 17:20:28', 1),
(771, 25, 278, 1, '2025-07-11 17:20:28', 1),
(772, 25, 279, 23, '2025-07-11 17:20:28', 1),
(773, 25, 280, 22, '2025-07-11 17:20:28', 1),
(774, 25, 281, 4, '2025-07-11 17:20:28', 1),
(775, 25, 282, 1, '2025-07-11 17:20:28', 1),
(776, 25, 283, 1, '2025-07-11 17:20:28', 1),
(777, 25, 284, 6, '2025-07-11 17:20:28', 1),
(778, 25, 285, 9, '2025-07-11 17:20:28', 1),
(779, 25, 286, 28, '2025-07-11 17:20:28', 1),
(780, 25, 287, 2, '2025-07-11 17:20:28', 1),
(781, 25, 288, 22, '2025-07-11 17:20:28', 1),
(782, 25, 289, 2, '2025-07-11 17:20:28', 1),
(783, 25, 290, 12, '2025-07-11 17:20:28', 1),
(784, 25, 291, 45, '2025-07-11 17:20:28', 1),
(785, 25, 292, 1, '2025-07-11 17:20:28', 1),
(786, 25, 293, 95, '2025-07-11 17:20:28', 1),
(787, 25, 294, 1, '2025-07-11 17:20:28', 1),
(788, 25, 295, 1, '2025-07-11 17:20:28', 1),
(789, 25, 296, 1, '2025-07-11 17:20:28', 1),
(790, 25, 297, 1, '2025-07-11 17:20:28', 1),
(791, 25, 298, 1, '2025-07-11 17:20:28', 1),
(792, 25, 299, 5, '2025-07-11 17:20:28', 1),
(793, 25, 300, 3, '2025-07-11 17:20:28', 1),
(794, 25, 301, 7, '2025-07-11 17:20:28', 1),
(795, 25, 302, 1, '2025-07-11 17:20:28', 1),
(796, 25, 303, 2, '2025-07-11 17:20:28', 1),
(797, 25, 304, 2, '2025-07-11 17:20:28', 1),
(798, 25, 305, 2, '2025-07-11 17:20:28', 1),
(799, 25, 306, 1, '2025-07-11 17:20:28', 1),
(800, 25, 307, 1, '2025-07-11 17:20:28', 1),
(801, 25, 308, 1, '2025-07-11 17:20:28', 1),
(802, 25, 309, 2, '2025-07-11 17:20:28', 1),
(803, 25, 310, 1, '2025-07-11 17:20:28', 1),
(804, 25, 311, 1, '2025-07-11 17:20:28', 1),
(805, 25, 312, 1, '2025-07-11 17:20:28', 1),
(806, 25, 313, 1, '2025-07-11 17:20:28', 1),
(807, 25, 314, 35, '2025-07-11 17:20:28', 1),
(808, 25, 315, 4, '2025-07-11 17:20:28', 1),
(809, 25, 316, 1, '2025-07-11 17:20:28', 1),
(810, 25, 317, 1, '2025-07-11 17:20:28', 1),
(811, 25, 318, 1, '2025-07-11 17:20:28', 1),
(812, 25, 319, 4, '2025-07-11 17:20:28', 1),
(813, 25, 320, 1, '2025-07-11 17:20:28', 1),
(814, 25, 321, 3, '2025-07-11 17:20:28', 1),
(815, 25, 322, 1, '2025-07-11 17:20:28', 1),
(816, 25, 323, 1, '2025-07-11 17:20:28', 1),
(817, 25, 324, 5, '2025-07-11 17:20:28', 1),
(818, 25, 325, 5, '2025-07-11 17:20:28', 1),
(819, 25, 326, 2, '2025-07-11 17:20:28', 1),
(820, 25, 327, 1, '2025-07-11 17:20:28', 1),
(821, 25, 328, 1, '2025-07-11 17:20:28', 1),
(822, 25, 329, 6, '2025-07-11 17:20:28', 1),
(823, 25, 330, 5, '2025-07-11 17:20:28', 1),
(824, 25, 331, 1, '2025-07-11 17:20:28', 1),
(825, 26, 259, 1, '2025-07-11 17:21:45', 1),
(826, 26, 260, 1, '2025-07-11 17:21:45', 1),
(827, 26, 261, 14, '2025-07-11 17:21:45', 1),
(828, 26, 262, 1, '2025-07-11 17:21:45', 1),
(829, 26, 263, 2, '2025-07-11 17:21:45', 1),
(830, 26, 264, 3, '2025-07-11 17:21:45', 1),
(831, 26, 265, 1, '2025-07-11 17:21:45', 1),
(832, 26, 266, 1, '2025-07-11 17:21:45', 1),
(833, 26, 267, 2, '2025-07-11 17:21:45', 1),
(834, 26, 268, 1, '2025-07-11 17:21:45', 1),
(835, 26, 269, 1, '2025-07-11 17:21:45', 1),
(836, 26, 270, 12, '2025-07-11 17:21:45', 1),
(837, 26, 271, 73, '2025-07-11 17:21:45', 1),
(838, 26, 272, 10, '2025-07-11 17:21:45', 1),
(839, 26, 273, 5, '2025-07-11 17:21:45', 1),
(840, 26, 274, 39, '2025-07-11 17:21:45', 1),
(841, 26, 275, 146, '2025-07-11 17:21:45', 1),
(842, 26, 276, 1, '2025-07-11 17:21:45', 1),
(843, 26, 277, 1, '2025-07-11 17:21:45', 1),
(844, 26, 278, 1, '2025-07-11 17:21:45', 1),
(845, 26, 279, 23, '2025-07-11 17:21:45', 1),
(846, 26, 280, 22, '2025-07-11 17:21:45', 1),
(847, 26, 281, 4, '2025-07-11 17:21:45', 1),
(848, 26, 282, 1, '2025-07-11 17:21:45', 1),
(849, 26, 283, 1, '2025-07-11 17:21:45', 1),
(850, 26, 284, 6, '2025-07-11 17:21:45', 1),
(851, 26, 285, 9, '2025-07-11 17:21:45', 1),
(852, 26, 286, 28, '2025-07-11 17:21:45', 1),
(853, 26, 287, 2, '2025-07-11 17:21:45', 1),
(854, 26, 288, 22, '2025-07-11 17:21:45', 1),
(855, 26, 289, 2, '2025-07-11 17:21:45', 1),
(856, 26, 290, 12, '2025-07-11 17:21:45', 1),
(857, 26, 291, 45, '2025-07-11 17:21:45', 1),
(858, 26, 292, 1, '2025-07-11 17:21:45', 1),
(859, 26, 293, 95, '2025-07-11 17:21:45', 1),
(860, 26, 294, 1, '2025-07-11 17:21:45', 1),
(861, 26, 295, 1, '2025-07-11 17:21:45', 1),
(862, 26, 296, 1, '2025-07-11 17:21:45', 1),
(863, 26, 297, 1, '2025-07-11 17:21:45', 1),
(864, 26, 298, 1, '2025-07-11 17:21:45', 1),
(865, 26, 299, 5, '2025-07-11 17:21:45', 1),
(866, 26, 300, 3, '2025-07-11 17:21:45', 1),
(867, 26, 301, 7, '2025-07-11 17:21:45', 1),
(868, 26, 302, 1, '2025-07-11 17:21:45', 1),
(869, 26, 303, 2, '2025-07-11 17:21:45', 1),
(870, 26, 304, 2, '2025-07-11 17:21:45', 1),
(871, 26, 305, 2, '2025-07-11 17:21:45', 1),
(872, 26, 306, 1, '2025-07-11 17:21:45', 1),
(873, 26, 307, 1, '2025-07-11 17:21:45', 1),
(874, 26, 308, 1, '2025-07-11 17:21:45', 1),
(875, 26, 309, 2, '2025-07-11 17:21:45', 1),
(876, 26, 310, 1, '2025-07-11 17:21:45', 1),
(877, 26, 311, 1, '2025-07-11 17:21:45', 1),
(878, 26, 312, 1, '2025-07-11 17:21:45', 1),
(879, 26, 313, 1, '2025-07-11 17:21:45', 1),
(880, 26, 314, 35, '2025-07-11 17:21:45', 1),
(881, 26, 315, 4, '2025-07-11 17:21:45', 1),
(882, 26, 316, 1, '2025-07-11 17:21:45', 1),
(883, 26, 317, 1, '2025-07-11 17:21:45', 1),
(884, 26, 318, 1, '2025-07-11 17:21:45', 1),
(885, 26, 319, 4, '2025-07-11 17:21:45', 1),
(886, 26, 320, 1, '2025-07-11 17:21:45', 1),
(887, 26, 321, 3, '2025-07-11 17:21:45', 1),
(888, 26, 322, 1, '2025-07-11 17:21:45', 1),
(889, 26, 323, 1, '2025-07-11 17:21:45', 1),
(890, 26, 324, 5, '2025-07-11 17:21:45', 1),
(891, 26, 325, 5, '2025-07-11 17:21:45', 1),
(892, 26, 326, 2, '2025-07-11 17:21:45', 1),
(893, 26, 327, 1, '2025-07-11 17:21:45', 1),
(894, 26, 328, 1, '2025-07-11 17:21:45', 1),
(895, 26, 329, 6, '2025-07-11 17:21:45', 1),
(896, 26, 330, 5, '2025-07-11 17:21:45', 1),
(897, 26, 331, 1, '2025-07-11 17:21:45', 1),
(898, 30, 260, 1, '2025-07-11 17:35:52', 1),
(899, 30, 272, 10, '2025-07-11 17:35:52', 1),
(900, 30, 332, 5, '2025-07-11 17:36:07', 1),
(901, 30, 333, 66, '2025-07-11 17:36:07', 1),
(902, 30, 287, 12, '2025-07-11 17:36:07', 1),
(903, 30, 260, 1, '2025-07-11 17:36:11', 1),
(904, 30, 272, 10, '2025-07-11 17:36:11', 1),
(905, 31, 260, 1, '2025-07-11 17:38:12', 1),
(906, 31, 272, 10, '2025-07-11 17:38:13', 1),
(907, 32, 259, 1, '2025-07-11 17:46:38', 1),
(908, 32, 260, 1, '2025-07-11 17:46:38', 1),
(909, 32, 261, 14, '2025-07-11 17:46:38', 1),
(910, 32, 262, 1, '2025-07-11 17:46:38', 1),
(911, 32, 263, 2, '2025-07-11 17:46:38', 1),
(912, 32, 264, 3, '2025-07-11 17:46:38', 1),
(913, 32, 265, 1, '2025-07-11 17:46:38', 1),
(914, 32, 266, 1, '2025-07-11 17:46:38', 1),
(915, 32, 267, 2, '2025-07-11 17:46:38', 1),
(916, 32, 268, 1, '2025-07-11 17:46:38', 1),
(917, 32, 269, 1, '2025-07-11 17:46:38', 1),
(918, 32, 270, 12, '2025-07-11 17:46:38', 1),
(919, 32, 271, 73, '2025-07-11 17:46:38', 1),
(920, 32, 272, 10, '2025-07-11 17:46:38', 1),
(921, 32, 273, 5, '2025-07-11 17:46:38', 1),
(922, 32, 274, 39, '2025-07-11 17:46:38', 1),
(923, 32, 275, 146, '2025-07-11 17:46:38', 1),
(924, 32, 276, 1, '2025-07-11 17:46:38', 1),
(925, 32, 277, 1, '2025-07-11 17:46:38', 1),
(926, 32, 278, 1, '2025-07-11 17:46:38', 1),
(927, 32, 279, 23, '2025-07-11 17:46:38', 1),
(928, 32, 280, 22, '2025-07-11 17:46:38', 1),
(929, 32, 281, 4, '2025-07-11 17:46:38', 1),
(930, 32, 282, 1, '2025-07-11 17:46:38', 1),
(931, 32, 283, 1, '2025-07-11 17:46:38', 1),
(932, 32, 284, 6, '2025-07-11 17:46:38', 1),
(933, 32, 285, 9, '2025-07-11 17:46:38', 1),
(934, 32, 286, 28, '2025-07-11 17:46:38', 1),
(935, 32, 287, 2, '2025-07-11 17:46:38', 1),
(936, 32, 288, 22, '2025-07-11 17:46:38', 1),
(937, 32, 289, 2, '2025-07-11 17:46:38', 1),
(938, 32, 290, 12, '2025-07-11 17:46:38', 1),
(939, 32, 291, 45, '2025-07-11 17:46:38', 1),
(940, 32, 292, 1, '2025-07-11 17:46:38', 1),
(941, 32, 293, 95, '2025-07-11 17:46:38', 1),
(942, 32, 294, 1, '2025-07-11 17:46:38', 1),
(943, 32, 295, 1, '2025-07-11 17:46:38', 1),
(944, 32, 296, 1, '2025-07-11 17:46:38', 1),
(945, 32, 297, 1, '2025-07-11 17:46:38', 1),
(946, 32, 298, 1, '2025-07-11 17:46:38', 1),
(947, 32, 299, 5, '2025-07-11 17:46:38', 1),
(948, 32, 300, 3, '2025-07-11 17:46:38', 1),
(949, 32, 301, 7, '2025-07-11 17:46:38', 1),
(950, 32, 302, 1, '2025-07-11 17:46:38', 1),
(951, 32, 303, 2, '2025-07-11 17:46:38', 1),
(952, 32, 304, 2, '2025-07-11 17:46:38', 1),
(953, 32, 305, 2, '2025-07-11 17:46:38', 1),
(954, 32, 306, 1, '2025-07-11 17:46:38', 1),
(955, 32, 307, 1, '2025-07-11 17:46:38', 1),
(956, 32, 308, 1, '2025-07-11 17:46:38', 1),
(957, 32, 309, 2, '2025-07-11 17:46:38', 1),
(958, 32, 310, 1, '2025-07-11 17:46:38', 1),
(959, 32, 311, 1, '2025-07-11 17:46:38', 1),
(960, 32, 312, 1, '2025-07-11 17:46:38', 1),
(961, 32, 313, 1, '2025-07-11 17:46:38', 1),
(962, 32, 314, 35, '2025-07-11 17:46:38', 1),
(963, 32, 315, 4, '2025-07-11 17:46:38', 1),
(964, 32, 316, 1, '2025-07-11 17:46:38', 1),
(965, 32, 317, 1, '2025-07-11 17:46:38', 1),
(966, 32, 318, 1, '2025-07-11 17:46:38', 1),
(967, 32, 319, 4, '2025-07-11 17:46:38', 1),
(968, 32, 320, 1, '2025-07-11 17:46:38', 1),
(969, 32, 321, 3, '2025-07-11 17:46:38', 1),
(970, 32, 322, 1, '2025-07-11 17:46:38', 1),
(971, 32, 323, 1, '2025-07-11 17:46:38', 1),
(972, 32, 324, 5, '2025-07-11 17:46:38', 1),
(973, 32, 325, 5, '2025-07-11 17:46:38', 1),
(974, 32, 326, 2, '2025-07-11 17:46:38', 1),
(975, 32, 327, 1, '2025-07-11 17:46:38', 1),
(976, 32, 328, 1, '2025-07-11 17:46:38', 1),
(977, 32, 329, 6, '2025-07-11 17:46:38', 1),
(978, 32, 330, 5, '2025-07-11 17:46:38', 1),
(979, 32, 331, 1, '2025-07-11 17:46:38', 1);

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
(256, 'Klemens', '', NULL, '123', 'LEU', NULL, 65, NULL, '2025-07-11 14:26:57'),
(259, '4 Gerilim girişi/Akım girişi', 'AS04AD-A', NULL, '500', 'DEL', NULL, 1, NULL, '2025-07-11 16:38:58'),
(260, 'AS200 PLC - 16DI / 12DO PNP, Dahili Ethernet / CAN', 'AS228P-A', NULL, NULL, 'DEL', NULL, 0, NULL, '2025-07-11 16:38:58'),
(261, 'AS16AP11P-A ,8D/8P Plc Ek Dijital Modül', 'AS16AP11P-A', NULL, NULL, 'DEL', NULL, 0, NULL, '2025-07-11 16:38:58'),
(262, 'Endüstriyel Ethernet DIACloud Bulut Yönlendiriciler', 'DX-2300LN-WW', NULL, NULL, 'DEL', NULL, 0, NULL, '2025-07-11 16:38:58'),
(263, 'A2 Servo Sürücü - 1000W', 'ASD-A2-1021-M', NULL, '0', 'DEL', NULL, 1, NULL, '2025-07-11 16:38:58'),
(264, 'A2 Servo Sürücü - 400 Watt', 'ASD-A2-0421-M', NULL, NULL, 'DEL', NULL, 0, NULL, '2025-07-11 16:38:58'),
(265, 'Pano Soğutma Termostat\'ı 0-70°C Ray Tipi - Emas 10A 230V AC', 'PTM111', NULL, NULL, 'EMAS', NULL, 0, NULL, '2025-07-11 16:38:58'),
(266, 'Pimli Plastik Kapı Switch - NC contact type', 'BS1010', NULL, NULL, 'EMAS', NULL, 0, NULL, '2025-07-11 16:38:58'),
(267, 'Vibrasyon Kontrol Cihazı', 'EPAC3-W-F', NULL, NULL, 'ENDA', NULL, 0, NULL, '2025-07-11 16:38:58'),
(268, 'Faz yokluğu, Faz sırası hatası, 1 N/O kontak DIN1 Ray Montaj', 'MKS-03', NULL, NULL, 'ENTES', NULL, 0, NULL, '2025-07-11 16:38:58'),
(269, 'HMI 10” TFT, 1024x600, Dirençli dokunmatik, 4 GB Flash bellek, 1x Ethernet, JMobile çalışma zamanı', 'ESMA10U301', NULL, NULL, 'EXOR', NULL, 0, NULL, '2025-07-11 16:38:58'),
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
(286, 'Geçişli terminal bloğu', '3209523', NULL, NULL, 'PXC', NULL, 0, NULL, '2025-07-11 16:38:58'),
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
(322, 'Güç ve kontrol kabloları', '18G0,75 YSLY-JZ', NULL, NULL, 'TSE', NULL, 0, NULL, '2025-07-11 16:38:59'),
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
(333, '', '987654321', NULL, NULL, '', NULL, 0, NULL, '2025-07-11 17:36:07');

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
(92, 259, 'Giris', 1, '2025-07-11 17:04:41', 1, NULL, 0, NULL);

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
  ADD UNIQUE KEY `proje_kodu` (`proje_kodu`),
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
  MODIFY `proje_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- Tablo için AUTO_INCREMENT değeri `proje_hareketleri`
--
ALTER TABLE `proje_hareketleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Tablo için AUTO_INCREMENT değeri `proje_urunleri`
--
ALTER TABLE `proje_urunleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=980;

--
-- Tablo için AUTO_INCREMENT değeri `urunler`
--
ALTER TABLE `urunler`
  MODIFY `urun_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=334;

--
-- Tablo için AUTO_INCREMENT değeri `urun_hareketleri`
--
ALTER TABLE `urun_hareketleri`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=93;

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
