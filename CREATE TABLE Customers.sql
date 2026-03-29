CREATE TABLE Customers (
    id INT NOT NULL PRIMARY KEY IDENTITY,
    firstName NVARCHAR (100) NOT NULL,
    lastName NVARCHAR (100) NOT NULL,
    email NVARCHAR (100) NOT NULL UNIQUE,
    phone NVARCHAR (100) NOT NULL,
    address NVARCHAR (100) NOT NULL,
    company NVARCHAR (100) NOT NULL,
    notes NVARCHAR (MAX) NOT NULL,
    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Customers (firstName, lastName, email, phone, address, company, notes)
VALUES 
('Alice', 'Johnson', 'alice.j@example.com', '555-1001', '101 Apple St, WA', 'Cloud Systems', 'Interested in Azure'),
('Bob', 'Miller', 'bob.m@tech.com', '555-1002', '202 Berry Ln, OR', 'Data Dynamics', 'New lead'),
('Charlie', 'Davis', 'charlie.d@web.dev', '555-1003', '303 Cherry Rd, NV', 'Web Wizards', 'Frequent caller'),
('Diana', 'Prince', 'diana.p@amazonia.org', '555-1004', '404 Date Ct, AZ', 'Shield Corp', 'High priority'),
('Ethan', 'Hunt', 'ethan.h@impossible.net', '555-1005', '505 Elder Way, UT', 'IMF Logistics', 'Check back next month'),
('Fiona', 'Gallagher', 'fiona.g@southside.com', '555-1006', '606 Fig Blvd, IL', 'Shameless Inc', 'Local client'),
('George', 'Costanza', 'george.c@vandelay.com', '555-1007', '707 Grape Dr, NY', 'Vandelay Industries', 'Late payments'),
('Hannah', 'Abbott', 'hannah.a@magic.edu', '555-1008', '808 Hazel Cir, MA', 'Hogwarts Ltd', 'Education sector'),
('Ian', 'Wright', 'ian.w@football.uk', '555-1009', '909 Ivy Ter, CO', 'Goal Getters', 'Referral from John');
