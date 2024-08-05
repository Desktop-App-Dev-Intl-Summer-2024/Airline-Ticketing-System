CREATE TABLE Users (
id INT IDENTITY (1000, 1) NOT NULL,
username varchar(20) not null,
password varchar(10) not null,
firstName varchar(30) not null,
lastName varchar(40) not null,
email varchar(30) not null,
dob date not null,
userType varchar(10),
CONSTRAINT UC_User UNIQUE (id,username)
);

