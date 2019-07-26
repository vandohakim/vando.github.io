-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 26 Jul 2019 pada 06.10
-- Versi server: 10.3.16-MariaDB
-- Versi PHP: 7.3.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_android`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_pegawai`
--

CREATE TABLE `tb_pegawai` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `age` int(100) NOT NULL,
  `weight` int(100) NOT NULL,
  `height` int(11) NOT NULL,
  `gender` text NOT NULL,
  `bmr` float NOT NULL,
  `bmi` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tb_pegawai`
--

INSERT INTO `tb_pegawai` (`id`, `name`, `age`, `weight`, `height`, `gender`, `bmr`, `bmi`) VALUES
(1, 'Setyuan', 23, 11, 234, 'Female', 13, 14),
(2, 'Edi', 0, 4500000, 0, '', 0, 0),
(3, 'Mboh', 0, 0, 0, '', 0, 145),
(4, 'GFusti', 22, 22, 22, '22', 12, 12),
(5, 'Hakim', 22, 111, 111, '11', 11, 21),
(6, 'Haji', 34, 12, 122, '21', 333, 111),
(8, 'Vando', 1, 1, 1, 'female', 10000, 661.7),
(12, 'Gusti', 23, 51, 160, 'Male', 19.9219, 1408.3),
(13, 'Gusti', 23, 51, 160, 'Male', 19.9219, 1408.3),
(14, 'Gusti', 23, 51, 160, 'Male', 19.9219, 1408.3),
(15, 'Gusti', 23, 51, 160, 'Male', 19.9219, 1408.3),
(18, 'Gusti', 23, 51, 160, 'Male', 19.9219, 1408.3),
(19, 'Gusti', 23, 51, 160, 'Male', 19.9219, 1408.3),
(20, 'Gusti', 23, 51, 160, 'Male', 1408.3, 19.9219),
(22, 'Gusti', 23, 51, 160, 'Male', 19.9219, 1408.3),
(23, 'Gusti', 23, 51, 160, 'Male', 19.9219, 1408.3),
(24, 'KD', 45, 61, 161, 'Female', 23.533, 1318.9),
(25, 'KD', 45, 61, 161, 'Female', 23.533, 1318.9),
(26, 'KD', 45, 61, 161, 'Female', 23.533, 1318.9),
(27, 'KD', 45, 61, 161, 'Female', 23.533, 1318.9),
(28, 'KD', 45, 61, 161, 'Female', 23.533, 1318.9),
(29, 'KD', 45, 61, 161, 'male', 23.533, 1400.7),
(30, 'Madonna', 70, 76, 158, 'Female', 0, 0),
(31, 'Madonna', 70, 76, 160, 'Female', 1343.6, 29.6875),
(33, 'Test26', 25, 69, 180, 'Male', 1741.3, 21.2963);

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tb_pegawai`
--
ALTER TABLE `tb_pegawai`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `tb_pegawai`
--
ALTER TABLE `tb_pegawai`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
