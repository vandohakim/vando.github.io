-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 27 Jul 2019 pada 03.04
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
-- Database: `kalkulatorcsharp`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `csharphw2`
--

CREATE TABLE `csharphw2` (
  `id` int(11) NOT NULL,
  `display` varchar(255) NOT NULL,
  `postorder` varchar(255) NOT NULL,
  `preorder` varchar(255) NOT NULL,
  `decimalresult` bigint(11) NOT NULL,
  `binaryresult` bigint(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `csharphw2`
--

INSERT INTO `csharphw2` (`id`, `display`, `postorder`, `preorder`, `decimalresult`, `binaryresult`) VALUES
(15, '', '0', '0', 55, 110111),
(16, '12+3*6', '0', '0', 30, 11110),
(18, '255+333', '0', '0', 588, 1001001100),
(21, '2222', '0', '0', 2222, 100010101110),
(23, '32+32', '0', '0', 64, 1000000),
(24, '32*6', '0', '0', 192, 11000000),
(25, '25', '0', '0', 25, 11001),
(26, '35*6', '0', '0', 210, 11010010),
(27, '66699/9', '0', '0', 7411, 1110011110011),
(28, '55+3-9', '0', '0', 49, 110001),
(29, '12+36/12', '0', '0', 15, 1111),
(30, '12+36/1', '0', '0', 48, 110000),
(31, '1', '0', '0', 1, 1),
(32, '1222', '0', '0', 1222, 10011000110),
(33, '089', '0', '0', 89, 1011001),
(34, '2+3*8-7', '238', '0', 19, 10011),
(35, '2+3*8-6', '238*+6-', '', 20, 10100),
(37, '5*4+8*7', '54*87*+', '+*54*87', 76, 1001100);

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `csharphw2`
--
ALTER TABLE `csharphw2`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `csharphw2`
--
ALTER TABLE `csharphw2`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
