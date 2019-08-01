-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 01 Agu 2019 pada 10.25
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
(37, '5*4+8*7', '54*87*+', '+*54*87', 76, 1001100),
(39, '5*8+3-3', '58*3+3-', '+*58-33', 40, 101000),
(41, '5*4+8*7/7', '54*87*7/+', '+*54/*877', 28, 11100);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=42;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
