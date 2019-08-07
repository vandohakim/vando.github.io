-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 22 Jul 2019 pada 08.08
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
-- Database: `pesbuk`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `photo` varchar(255) NOT NULL DEFAULT 'default.svg',
  `birthday` date NOT NULL,
  `gender` char(10) NOT NULL,
  `occupation` char(10) NOT NULL,
  `favcolor` text NOT NULL,
  `phone` bigint(20) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT current_timestamp(),
  `file` varchar(500) NOT NULL,
  `filename` varchar(200) NOT NULL,
  `file_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `users`
--

INSERT INTO `users` (`id`, `username`, `email`, `password`, `name`, `photo`, `birthday`, `gender`, `occupation`, `favcolor`, `phone`, `timestamp`, `file`, `filename`, `file_id`) VALUES
(7, 'titidj', 'titi@gmail.com', '$2y$10$.ThW6VK1OKo5OBhVUDQ6MeQFM.QRc8ZwYUzmD1UGnDT.zhPHNfb2C', 'titi', 'default.svg', '2222-02-22', 'Female', 'Other', '#80ff00', 11111, '0000-00-00 00:00:00', '', '', 0),
(8, 'kd', 'kd@kd.com', '$2y$10$pXgAqDb/eImcnyrTbw9xPuCBCrRy1VA.Qanv2chp4br0/MJdlnm4S', 'kd', 'default.svg', '1111-11-11', 'Male', 'Other', '#804040', 1234, '0000-00-00 00:00:00', '', '', 0),
(9, 'ruth', 'ruth@gmial.com', '$2y$10$fc529.wABhXGPuGHUUvFhOwcRQaPO5/sZ54MivxSAr5L6vxj0qCqy', 'ruth', 'default.svg', '4342-02-11', 'Male', 'Other', '#ff8000', 4444, '0000-00-00 00:00:00', '', '', 0),
(10, 'gusti', 'a@a.com', '$2y$10$DAWHRGnRzzO7fbJ9SdpW3.Ju4IoDGZybHBTkv4hv9RnduTPYKXtbO', 'vando', 'default.svg', '4567-03-12', 'Female', 'Teacher', '#80ff00', 12345, '0000-00-00 00:00:00', '', '', 0),
(11, 'coba', 'coba@coba.com', '$2y$10$7fyVcGgVROgroGMO0E6ktuBvJ33TsroYfLuYYJyYP9BXcVDf.Bw6e', 'coba', 'default.svg', '1234-03-12', 'Male', 'Student', '#008000', 8888, '2019-07-20 07:24:29', '', '', 0),
(12, 'halo', 'a@a.com', '$2y$10$/fdcU7P3DK3bf0ZeM5JbYegP0P7pKloPrvBq7v2hhea4hoJQ7.hK6', 'aaaaaaaaaaaaaaaaaaaa', 'default.svg', '1124-11-11', 'Male', 'Teacher', '#ff80ff', 1111, '2019-07-20 08:17:51', '', '', 0),
(14, 'VandoGustiAlHakim', 'a@a.com', '$2y$10$F0ybe5zB2P9AnY0tsu2dqui.iVukwLG0AnWXPVnqPgLrULOLdfXLW', 'Vando Gusti Al Hakim', 'default.svg', '4555-03-12', 'Male', 'Student', '#ff0080', 1234, '2019-07-20 08:24:27', '', '', 0),
(16, 'titi', 'a@a.com', '$2y$10$NcND6elZvco8zwf566f3PefnV2rNzfBEK.6gdWOJOFXqpbcscoFs.', 'titi', 'default.svg', '2222-11-11', 'Male', 'Student', '#ff80ff', 88888, '2019-07-22 05:01:22', '', '', 0);

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
