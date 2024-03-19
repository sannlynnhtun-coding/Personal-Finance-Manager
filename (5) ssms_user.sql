-- Create a login for the user
CREATE LOGIN housewife WITH PASSWORD = 'admin';

-- Use the housewife login
USE housewife;

-- Create a user for the login in the housewife database
CREATE USER housewife FOR LOGIN housewife;

-- Make the user the database owner
ALTER ROLE db_owner ADD MEMBER housewife;

ALTER AUTHORIZATION ON SCHEMA::[db_owner] TO [housewife]
