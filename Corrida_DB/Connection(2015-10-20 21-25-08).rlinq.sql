-- add column for field _codPais
ALTER TABLE `local` ADD COLUMN `CodPais` integer NULL
;

UPDATE `local` SET `CodPais` = 0
;

ALTER TABLE `local` CHANGE COLUMN `CodPais` `CodPais` integer NOT NULL
;

