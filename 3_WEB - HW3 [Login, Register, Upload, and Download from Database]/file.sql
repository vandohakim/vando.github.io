-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 22 Jul 2019 pada 14.54
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
-- Database: `system`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `file`
--

CREATE TABLE `file` (
  `file_id` int(11) NOT NULL,
  `name` varchar(200) NOT NULL,
  `file` varchar(500) NOT NULL,
  `size` int(11) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `file`
--

INSERT INTO `file` (`file_id`, `name`, `file`, `size`, `timestamp`) VALUES
(25, 'logout', 'files/logout.php', 81, '2019-07-22 12:36:29'),
(26, 'applications', 'files/applications.html', 3607, '2019-07-22 12:36:29'),
(27, 'bitnami', 'files/bitnami.css', 177, '2019-07-22 12:36:29'),
(28, 'auth', 'files/auth.php', 87, '2019-07-22 12:36:29'),
(29, 'register', 'files/register.php', 4909, '2019-07-22 12:36:29'),
(30, 'timeline', 'files/timeline.php', 6549, '2019-07-22 12:36:29'),
(31, 'file', 'files/file.sql', 1714, '2019-07-22 12:36:29'),
(32, 'lazysizes', 'files/lazysizes.min.js', 6582, '0000-00-00 00:00:00'),
(33, 'twemoji', 'files/twemoji.min.js', 15304, '2019-07-22 12:47:18');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `file`
--
ALTER TABLE `file`
  ADD PRIMARY KEY (`file_id`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `file`
--
ALTER TABLE `file`
  MODIFY `file_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
