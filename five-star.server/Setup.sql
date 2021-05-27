CREATE TABLE accounts (
  id VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  picture VARCHAR(255) NOT NULL,
  PRIMARY KEY (id)
);
CREATE TABLE restaurants (
  id VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  location VARCHAR(255) NOT NULL,
  owner VARCHAR(255) NOT NULL,
  PRIMARY KEY (id)
);
CREATE TABLE reviews (
  id VARCHAR(255) NOT NULL,
  title VARCHAR(255) NOT NULL,
  body VARCHAR(255) NOT NULL,
  owner VARCHAR(255) NOT NULL,
  rating INT NOT NULL,
  PRIMARY KEY (id)
);