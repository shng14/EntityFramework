-- Create a new database called 'demodb'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'demodb'
)
CREATE DATABASE demodb
GO
-- Create a new table called '[demotbl]' in schema '[dbo]' in database '[demodb]'
-- Drop the table if it already exists
IF OBJECT_ID('[demodb].[dbo].[demotbl]', 'U') IS NOT NULL
DROP TABLE [demodb].[dbo].[demotbl]
GO
-- Create the table in the specified database and schema
CREATE TABLE [demodb].[dbo].[demotbl]
(
    demoID INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Primary Key column
    [demoCode] [VARCHAR](50) NOT NULL,
    [demoName] [VARCHAR](50) NOT NULL
    -- Specify more columns here
);
GO
-- Insert rows into table 'demotbl' in schema '[dbo]' in database '[demodb]'
INSERT INTO [demodb].[dbo].[demotbl]
VALUES
( -- First row: values for the columns in the list above
 'Bin','Nguyen Hoang Anh Khoa'
),
( -- Second row: values for the columns in the list above
 'Nhi','Nguyen Hoang Yen Nhi'
)
-- Add more rows here
GO
-- Select rows from a Table or View '[demotbl]' in schema '[dbo]' in database '[demodb]'
SELECT * FROM [demodb].[dbo].[demotbl]
GO