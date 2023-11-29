CREATE TABLE IF NOT EXISTS Users (
	User_id SERIAL PRIMARY KEY, 
	first_name VARCHAR(50),
	last_name VARCHAR(50),
	is_Admin BOOLEAN NOT NULL, 
	email VARCHAR(255) UNIQUE NOT NULL,
	username VARCHAR(50) UNIQUE NOT NULL,
	password VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS Books (
	Book_id SERIAL PRIMARY KEY,
	title VARCHAR(255),
	publisher VARCHAR(255),
	dev_language VARCHAR(50),
	date_published DATE
);

CREATE TABLE IF NOT EXISTS CheckedOut (
	User_id INT NOT NULL,
	Book_id INT NOT NULL,
	is_checkedout BOOLEAN NOT NULL,
	checked_out_time TIMESTAMP NOT NULL DEFAULT now(),
	PRIMARY KEY (Book_id, checked_out_time),
	FOREIGN KEY (User_id) REFERENCES Users (User_id),
	FOREIGN KEY (Book_id) REFERENCES Books (Book_id) 
);

CREATE TABLE IF NOT EXISTS Classes (
	Class_id SERIAL PRIMARY KEY,
	class_name VARCHAR(255), 
	class_description VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS AsscoiatedWith (
	Class_id INT NOT NULL,
	Book_id INT NOT NULL,
	is_required BOOLEAN NOT NULL,
	PRIMARY KEY (Class_id, Book_id),
	FOREIGN KEY (Class_id) REFERENCES Classes (Class_id),
	FOREIGN KEY (Book_id) REFERENCES Books (Book_id) 
);

CREATE TABLE IF NOT EXISTS Author (
	Author_id SERIAL PRIMARY KEY,
	first_name VARCHAR(50),
	last_name VARCHAR(50)
);

CREATE TABLE IF NOT EXISTS AuthoredBy (
	Author_id INT NOT NULL,
	Book_id INT NOT NULL,
	PRIMARY KEY (Author_id, Book_id),
	FOREIGN KEY (Author_id) REFERENCES Author (Author_id),
	FOREIGN KEY (Book_id) REFERENCES Books (Book_id) 
);

INSERT INTO Users (first_name, last_name, is_Admin, email, username, password)
VALUES ('John', 'Doe', TRUE, 'john.doe@ndsu.edu', 'admin', 'admin'),
('Jane', 'Doe', FALSE, 'jane.doe@ndsu.edu', 'janedoe', 'password');


INSERT INTO Books (title, publisher, dev_language, date_published)
VALUES ('testbook', 'testpublisher', 'Python..gross', '1987-08-14'),
('testbook2', 'testpublisher2', 'C#...gross', '1983-07-23');

INSERT INTO CheckedOut (User_id, Book_id, is_checkedout)
VALUES (1, 1, TRUE),
(1, 2, FALSE);

INSERT INTO Classes (class_name, class_description) 
VALUES ('CSCI-160', 'NDSUs Intro into computer science.'),
('CSCI-161', 'NDSUs second computer science class with data structures.');


INSERT INTO AsscoiatedWith (Class_id, Book_id, is_required)
VALUES (1, 2, FALSE), 
(2, 2, FALSE);

INSERT INTO Author (first_name, last_name)
VALUES ('testAuthor', 'testLastName'), 
('testAuthor2', 'testLastName2');

INSERT INTO AuthoredBy (Author_id, Book_id)
VALUES (2, 2), 
(1, 1);