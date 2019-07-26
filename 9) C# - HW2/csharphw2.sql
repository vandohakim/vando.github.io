-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 26 Jul 2019 pada 17.27
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
  `postorder` bigint(11) NOT NULL,
  `preorder` bigint(11) NOT NULL,
  `decimalresult` bigint(11) NOT NULL,
  `binaryresult` bigint(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `csharphw2`
--

INSERT INTO `csharphw2` (`id`, `display`, `postorder`, `preorder`, `decimalresult`, `binaryresult`) VALUES
(14, '', 0, 0, 10, 1010),
(15, '', 0, 0, 55, 110111),
(16, '12+3*6', 0, 0, 30, 11110),
(18, '255+333', 0, 0, 588, 1001001100),
(21, '2222', 0, 0, 2222, 100010101110);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
