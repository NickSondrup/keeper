CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS keeps(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'Keeps ID',
  creatorId VARCHAR(255) NOT NULL comment 'creator ID',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Time created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP  ON UPDATE CURRENT_TIMESTAMP comment 'Time last updated',
  name VARCHAR(255) NOT NULL comment 'Name of keep',
  description VARCHAR(255) NOT NULL comment 'Description of keep',
  img VARCHAR(255) NOT NULL comment 'image URL',
  views INT NOT NULL DEFAULT 0 comment 'how many times this keep has been clicked',
  shares INT NOT NULL DEFAULT 0 comment 'how many times this keep has been shared',
  keeps INT NOT NULL DEFAULT 0 comment 'how many times this keep has been kept',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) DEFAULT CHARSET utf8 comment '';

CREATE TABLE IF NOT EXISTS vaults(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'Valuts ID',
  creatorId VARCHAR(255) NOT NULL comment 'creator ID',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Time created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP  ON UPDATE CURRENT_TIMESTAMP comment 'Time last updated',
  name VARCHAR(255) NOT NULL comment 'Name of Vault',
  description VARCHAR(255) NOT NULL comment 'Description of vault',
  isPrivate TINYINT DEFAULT 0 comment 'bool for if vault is private or not',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) DEFAULT CHARSET utf8 comment '';

CREATE TABLE IF NOT EXISTS vault_keeps(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'ID of vaultKeep',
  creatorId VARCHAR(255) NOT NULL comment 'creator ID',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Time created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP  ON UPDATE CURRENT_TIMESTAMP comment 'Time last updated',
  vaultId INT NOT NULL comment 'Id of vault item is attached to',
  keepId INT NOT NULL comment 'Id of keep item is attached to',
  FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
) DEFAULT CHARSET utf8 comment '';


