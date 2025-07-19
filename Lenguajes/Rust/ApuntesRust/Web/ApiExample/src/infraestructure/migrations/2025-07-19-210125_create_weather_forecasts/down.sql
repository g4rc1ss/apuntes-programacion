-- This file should undo anything in `up.sql`
CREATE TABLE `weatherforecast`(
	`id` INTEGER NOT NULL PRIMARY KEY,
	`temperature` INTEGER
);

DROP TABLE IF EXISTS `weatherforecast`;
