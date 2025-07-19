-- Your SQL goes here
DROP TABLE IF EXISTS `weatherforecast`;
CREATE TABLE `weatherforecast`(
	`id` INTEGER NOT NULL PRIMARY KEY,
	`temperature` INTEGER
);

INSERT INTO weatherforecast values (1, 20), (2, 50)

