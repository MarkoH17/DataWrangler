# Data Wrangler Software

Inspired by a non-profit organization in Colorado focused on preserving local history that spans hundreds of years, Data Wrangler was born. The client needed a way to migrate their dissimilar data from dozens of Microsoft Excel spreadsheets to an easy to use application with little hassle. We created Data Wrangler to fill this need, and we think that others can use and build on our software to make managing scattered, dissimilar data easy, safer, and reliable.

This project was created for a senior capstone course required for students to graduate from a Colorado university. One of the primary focuses of the project was to spend a lot of time considering the use cases of the software, and to design the architecture to support current and future use cases. This taught our team a lot, and I am grateful for this experience.

This software wouldn't have been possible without the rest of the team ([Aaron Skilling](https://github.com/askilling) and [Hunter Stephens](https://github.com/Agent531C)). Thanks to the [LiteDB](http://www.litedb.org/) team for providing such an elegant solution for accessing NoSQL Document Stores with little overhead (and with great C# integration!).

_Landing Screen_

![Landing](/Screenshots/Landing.PNG)

####
****

## Getting Started - Downloading
Visit the [Releases](https://github.com/MarkoH17/DataWrangler/releases) tab to browse our release history, or get the latest release [here](https://github.com/MarkoH17/DataWrangler/releases/latest)

## Features - Modular Database
Built atop LiteDB, Data Wrangler is fast and stores data in a self-contained file ending in a .db extension. This makes it easy to transfer the database file between servers or across desktops when necessary. LiteDB also makes it possible to delegate concurrent user access, although Data Wrangler only supports serialized reads (one at a time) due to the architecture chosen for our initial client. Our use case demanded our software to support 5-10 users on the system, and we feel like anything more than this should require a different tool for the job.

## Features - Object Auditing
User accounts, Record types, and Records all support the auditing capability build into Data Wrangler. Audit entires are automatically recorded in the database as certain events occur, including: create, update, delete, login success, login failure, add attachment, remove attachment. Audit entries can be viewed at a per-object level, or aggregated by user account.

_Record Audit History_

![Record History](/Screenshots/Audit_Record.PNG)


## Features - Import Data
Importing data from Microsoft Excel spreadsheets is made easy and is powered by [EPPlus (v4.5.3)](https://github.com/JanKallman/EPPlus).

_Import Excel Data_

![Import Data](/Screenshots/Import.PNG)

## Features - Managing Schema
Managing schema through 'record types' is an easy way to add, update, and delete attributes used to store key-value data in 'records'.

_Manage Record Schema_

![Record Types](/Screenshots/Record_Types.PNG)

## Features - Managing Records
Managing records is made possible through a fast UI that supports filtering by keywords. This makes it easy to view all records of a certain type, or only records that match certain criteria. We would like to expand to support advanced queries, allowing users to specify criteria using boolean operators (e.g. 'FirstName' = 'John' AND 'LastName' = 'Doe) through a graphical query builder. Records can also store more than just text data! Files of any kind can also be added to a record as an attachment, which is implemented through LiteDB's FileStorage mechanism, which streams the binary contents into the database for reliable retrieval. 

_Manage Records_

![Manage Records](/Screenshots/Records.PNG)

## Features - Managing User Access and Security
User accounts make it possible to secure unauthorized access to the database. Passwords are hashed in a function that applies a 16 byte (pseudo) random salt and then 1000 rounds of [PBKDF2,](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rfc2898derivebytes) which is implemented with HMACSHA1. It is worth mentioning that encryption of the LiteDB database was not implemented in this project - this is easy to accomplish and can be enabled by adding a value to the database connection string. Check out the [LiteDB Encryption Docs](http://www.litedb.org/docs/encryption/) to learn more about encryption. ***We do not recommend using Data Wrangler to store any sensitive information without the proper implementation of access controls or encryption. Use of Data Wrangler at your own risk***

_Manage Users_

![User Accounts](/Screenshots/Users.PNG)

_User Audit History_
![Import Data](/Screenshots/Audit_Users.PNG)

## Features - Customization
Customizing the look and feel of Data Wrangler makes it possible to streamline the user experience to adhere to an organization's branding.

_Options_

![Options](/Screenshots/Options.PNG)

_Non-comprehensive collage of look and feels_
![Themes Collage](/Screenshots/Themed/Themes_Collage.PNG)


## Future Plans
Although the development of Data Wrangler is paused at the moment, we encourage others to fork this repository to continue the development of Data Wrangler. Not a Developer? Perhaps download the [latest release](https://github.com/MarkoH17/DataWrangler/releases) to see if it meets your needs.
