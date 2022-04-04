ALTER TABLE `books`
  ADD COLUMN `enabled` BIT(1) NOT NULL DEFAULT b'1' AFTER `launch_date`;
  