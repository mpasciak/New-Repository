-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 19 Cze 2019, 14:50
-- Wersja serwera: 10.3.15-MariaDB
-- Wersja PHP: 7.1.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `quizdb`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `closedquestion`
--

CREATE TABLE `closedquestion` (
  `id` int(11) NOT NULL,
  `question` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL,
  `exam_id` int(11) NOT NULL,
  `Points` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `closedquestion`
--

INSERT INTO `closedquestion` (`id`, `question`, `exam_id`, `Points`) VALUES
(1, 'Co stanie się po wciśnięciu przycisków CTRL, ALT i DEL w systemach Linux i systemach Windows do wersji 9x?', 1, 2),
(2, 'Jak nazywa się port, na który podłączano kiedyś myszkę?', 1, 3),
(3, 'Które gry były składnikami systemu Windows XP?', 1, 1),
(4, 'Jaki jest wzór na prawo Ohma?', 2, 1),
(5, 'Do czego słuzy Mostek Graetz\'a?', 2, 2),
(6, 'W której minucie gry pojawia się \"Baron Nashor\"', 3, 1),
(7, 'Ile RP kosztuje skin do PulseFire Ezreala', 3, 2),
(8, 'Które potwory w lesie dają najwięcej EXP\'a', 3, 3),
(9, 'Jak nazywa się najnowsza seria kart graficznych Nvidia', 1, 1),
(10, 'Który z wymienionych procesorów jest obecnie najlepszy na rynku do zastosowań konsumenckich', 1, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `closedquestionanswer`
--

CREATE TABLE `closedquestionanswer` (
  `id` int(11) NOT NULL,
  `answer` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL,
  `is_correct` tinyint(1) NOT NULL,
  `closed_question_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `closedquestionanswer`
--

INSERT INTO `closedquestionanswer` (`id`, `answer`, `is_correct`, `closed_question_id`) VALUES
(1, 'Zresetujemy komputer', 1, 1),
(2, 'Wejdziemy do menadżera zadań', 0, 1),
(3, 'Usuniemy system', 0, 1),
(4, 'Skopiujemy plik', 0, 1),
(5, 'Pinball, Tetris, Arkanoid, Puzznic', 0, 3),
(6, 'FreeCell, Pasjans Pająk, Mahjogg, Pinball', 0, 3),
(7, 'Mahjogg, Saper, Pinball, Puzznic', 0, 3),
(8, 'Saper, Kierki, FreeCall, Pasjans Pająk', 1, 3),
(9, 'PCI', 0, 2),
(10, 'Ps/2', 1, 2),
(11, 'COM1', 0, 2),
(12, 'AGP', 0, 2),
(13, 'I=U/R', 1, 4),
(14, 'R=I/U', 0, 4),
(15, 'I=U*R', 0, 4),
(16, 'R=U*I', 0, 4),
(17, 'Inwersji obrazu', 0, 5),
(18, 'Stabilizacji obrazu', 0, 5),
(19, 'Wzmacniania amplitudy', 0, 5),
(20, 'Prostowania napięcia', 1, 5),
(21, '15', 0, 6),
(22, '20', 1, 6),
(23, '18', 0, 6),
(24, '17', 0, 6),
(25, '3250 ', 1, 7),
(26, '1920', 0, 7),
(27, '1350', 0, 7),
(28, '2775', 0, 7),
(29, 'Zjawy', 0, 8),
(30, 'Wilki', 0, 8),
(31, 'Golemy', 1, 8),
(32, 'Gromp', 0, 8),
(33, 'Seria GTX', 0, 9),
(34, 'Seria RTX', 1, 9),
(35, 'Seria Navi', 0, 9),
(36, 'Seria Ryzen', 0, 9),
(41, 'Intel Core i9-9900k', 1, 10),
(42, 'Intel Core I9-9980XE', 0, 10),
(43, 'Ryzen 2700X', 0, 10),
(44, 'AMD Epyc 7601', 0, 10);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `exam`
--

CREATE TABLE `exam` (
  `id` int(11) NOT NULL,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL,
  `time` int(11) NOT NULL,
  `closed_quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `exam`
--

INSERT INTO `exam` (`id`, `name`, `time`, `closed_quantity`) VALUES
(1, 'Egzamin z wiedzy o komputerach', 360, 5),
(2, 'Egzamin z Podstaw Elektroniki i Elektrotechniki', 15, 2),
(3, 'Egzamin wiedzy o Lidze Legend', 600, 3);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `examtologin`
--

CREATE TABLE `examtologin` (
  `id` int(11) NOT NULL,
  `exam_id` int(11) NOT NULL,
  `login_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `examtologin`
--

INSERT INTO `examtologin` (`id`, `exam_id`, `login_id`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 2, 2),
(4, 3, 3);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `first_name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL,
  `last_name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL,
  `student_id` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL,
  `password` text CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `login`
--

INSERT INTO `login` (`id`, `first_name`, `last_name`, `student_id`, `password`) VALUES
(1, 'Mateusz', 'Paściak', 'w58924', '1qazXSW@'),
(2, 'Adrian', 'Wlazło', 'w58894', 'Adrian123'),
(3, 'Patryk', 'Plej', 'w99999', 'zyraotp123');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `result`
--

CREATE TABLE `result` (
  `id` int(11) NOT NULL,
  `exam_id` int(11) NOT NULL,
  `login_id` int(11) NOT NULL,
  `score` int(11) NOT NULL,
  `max_score` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `closedquestion`
--
ALTER TABLE `closedquestion`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `closedquestionanswer`
--
ALTER TABLE `closedquestionanswer`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `exam`
--
ALTER TABLE `exam`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `examtologin`
--
ALTER TABLE `examtologin`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `result`
--
ALTER TABLE `result`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `closedquestion`
--
ALTER TABLE `closedquestion`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT dla tabeli `closedquestionanswer`
--
ALTER TABLE `closedquestionanswer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT dla tabeli `exam`
--
ALTER TABLE `exam`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `examtologin`
--
ALTER TABLE `examtologin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT dla tabeli `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `result`
--
ALTER TABLE `result`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
