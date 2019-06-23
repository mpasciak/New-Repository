-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 04 Maj 2019, 02:18
-- Wersja serwera: 10.1.31-MariaDB
-- Wersja PHP: 7.2.3

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
(3, 'Które gry były składnikami systemu Windows XP?', 1, 1);

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
(5, 'Pinball, Tetris, Arkanoid, Puzznic', 0, 2),
(6, 'FreeCell, Pasjans Pająk, Mahjogg, Pinball', 0, 2),
(7, 'Mahjogg, Saper, Pinball, Puzznic', 0, 2),
(8, 'Saper, Kierki, FreeCall, Pasjans Pająk', 1, 2),
(9, 'PCI', 0, 3),
(10, 'Ps/2', 1, 3),
(11, 'COM1', 0, 3),
(12, 'AGP', 0, 3);

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
(1, 'Egzamin z wiedzy o komputerach', 15, 2),
(2, 'Egzamin z Podstaw Elektroniki i Elektrotechniki', 15, 2);

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
(1, 1, 1);

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
(1, 'Mateusz', 'Paściak', 'w58924', '1qazXSW@');

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
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `result`
--

INSERT INTO `result` (`id`, `exam_id`, `login_id`, `score`, `max_score`, `created_at`) VALUES
(1, 1, 1, 4, 4, '2019-05-04 00:16:34');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `closedquestionanswer`
--
ALTER TABLE `closedquestionanswer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT dla tabeli `exam`
--
ALTER TABLE `exam`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT dla tabeli `examtologin`
--
ALTER TABLE `examtologin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `result`
--
ALTER TABLE `result`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
