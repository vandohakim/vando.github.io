-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 01 Agu 2019 pada 01.25
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
-- Database: `forum`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `categories`
--

CREATE TABLE `categories` (
  `cat_id` int(11) NOT NULL,
  `cat_name` varchar(255) NOT NULL,
  `cat_description` varchar(255) NOT NULL,
  `cat_by` varchar(255) NOT NULL,
  `cat_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `categories`
--

INSERT INTO `categories` (`cat_id`, `cat_name`, `cat_description`, `cat_by`, `cat_date`) VALUES
(1, 'Sayur Singkong', 'Bayem, Kangkung, Selada', 'gustiaja', '2019-08-01 06:02:05'),
(2, 'Lauk Makan', 'Ayam, Kucing, Biawak', 'gustiaja', '2019-08-01 06:01:44'),
(5, 'Minuman', 'Jus, Kopi, Teh', 'vandoaja', '2019-08-01 06:04:14'),
(6, 'Penutup', 'Dessert sedep', 'vandoaja', '2019-08-01 06:04:17'),
(7, 'Coba aja', 'halo ini apaa ya?', 'alhakim', '2019-08-01 06:03:50'),
(8, 'Roti', 'ada roti maryam', 'alhakim', '2019-08-01 06:03:54'),
(9, 'Pembuka Makan', 'pasti buah-buahan', 'fanhaijin', '2019-08-01 06:06:23'),
(11, 'Bad Guy', 'Billie Eilish!', 'fanhaijin', '2019-08-01 06:07:35');

-- --------------------------------------------------------

--
-- Struktur dari tabel `posts`
--

CREATE TABLE `posts` (
  `post_id` int(11) NOT NULL,
  `post_content` text NOT NULL,
  `post_date` datetime NOT NULL,
  `post_topic` int(11) NOT NULL,
  `post_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `posts`
--

INSERT INTO `posts` (`post_id`, `post_content`, `post_date`, `post_topic`, `post_by`) VALUES
(4, 'Obat masuk angin dari sayur?', '2019-07-31 13:13:45', 4, 18),
(5, 'kentut\r\n', '2019-07-31 14:33:25', 4, 18),
(6, 'bau dong!', '2019-07-31 14:51:34', 4, 19),
(7, 'Apa aja kayak roti, daging, kue', '2019-07-31 14:51:59', 5, 19),
(8, 'ciki, jajan, better', '2019-07-31 14:52:47', 6, 19),
(9, 'Zhenzhu NaiCha', '2019-07-31 15:01:28', 7, 19),
(11, 'Masak sihh??', '2019-07-31 17:29:51', 7, 18),
(20, 'Kemana aja sih loe?', '2019-08-01 00:05:59', 7, 29),
(21, 'halooo ku malah nih makan ', '2019-08-01 00:23:08', 10, 29),
(22, 'Makan bawang', '2019-08-01 06:05:59', 6, 30),
(23, 'Tulut tuut tuut kereta api', '2019-08-01 06:23:57', 11, 30);

-- --------------------------------------------------------

--
-- Struktur dari tabel `topics`
--

CREATE TABLE `topics` (
  `topic_id` int(11) NOT NULL,
  `topic_subject` varchar(255) NOT NULL,
  `topic_date` datetime NOT NULL,
  `topic_cat` int(11) NOT NULL,
  `topic_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `topics`
--

INSERT INTO `topics` (`topic_id`, `topic_subject`, `topic_date`, `topic_cat`, `topic_by`) VALUES
(4, 'Herbal hapus', '2019-07-31 23:33:11', 1, 18),
(5, 'Herbal lauk', '2019-08-01 05:10:34', 2, 19),
(6, 'magnum', '2019-08-01 05:11:05', 2, 19),
(7, 'percobaan', '2019-08-01 05:10:49', 5, 19),
(10, 'Zhenzu aja', '2019-08-01 00:22:47', 6, 29),
(11, 'JBieberAJAHww', '2019-08-01 06:19:17', 11, 30);

-- --------------------------------------------------------

--
-- Struktur dari tabel `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `user_name` varchar(30) NOT NULL,
  `user_pass` varchar(255) NOT NULL,
  `user_email` varchar(255) NOT NULL,
  `user_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `users`
--

INSERT INTO `users` (`user_id`, `user_name`, `user_pass`, `user_email`, `user_date`) VALUES
(18, 'vandoaja', 'aa', 'vandoaja@gmail.com', '2019-07-31 10:37:16'),
(19, 'gustiaja', 'ss', 'gustiaja@gmail.com', '2019-07-31 14:50:00'),
(29, 'alhakim', 'dd', 'alhakim@gmail.com', '2019-08-01 00:01:58'),
(30, 'fanhaijin', 'ff', 'fanhaijin@gmail.com', '2019-08-01 00:25:02');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`cat_id`),
  ADD UNIQUE KEY `cat_name` (`cat_name`);

--
-- Indeks untuk tabel `posts`
--
ALTER TABLE `posts`
  ADD PRIMARY KEY (`post_id`),
  ADD KEY `post_topic` (`post_topic`),
  ADD KEY `post_by` (`post_by`);

--
-- Indeks untuk tabel `topics`
--
ALTER TABLE `topics`
  ADD PRIMARY KEY (`topic_id`),
  ADD KEY `topic_cat` (`topic_cat`),
  ADD KEY `topic_by` (`topic_by`);

--
-- Indeks untuk tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `categories`
--
ALTER TABLE `categories`
  MODIFY `cat_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT untuk tabel `posts`
--
ALTER TABLE `posts`
  MODIFY `post_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT untuk tabel `topics`
--
ALTER TABLE `topics`
  MODIFY `topic_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT untuk tabel `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `posts`
--
ALTER TABLE `posts`
  ADD CONSTRAINT `posts_ibfk_1` FOREIGN KEY (`post_topic`) REFERENCES `topics` (`topic_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `posts_ibfk_2` FOREIGN KEY (`post_by`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE;

--
-- Ketidakleluasaan untuk tabel `topics`
--
ALTER TABLE `topics`
  ADD CONSTRAINT `topics_ibfk_1` FOREIGN KEY (`topic_cat`) REFERENCES `categories` (`cat_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `topics_ibfk_2` FOREIGN KEY (`topic_by`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
