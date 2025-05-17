# InActive Login Tracker

This C# console application filters a list of users to identify those who have been inactive for a defined number of days. It simulates a real-world backend feature, such as notifying administrators about user accounts that may require attention or cleanup due to inactivity.


## Objective

Given a list of users with their `UserId` and `LastLogin` date, return a list of users whose last login is **older than `X` days ago**.


## Features

- Validates input list and days threshold
- Treats default `DateTime` (`01/01/0001`) as inactive
- Logs a warning if a user’s `LastLogin` date is in the future
- Skips users with null or empty `UserId`
- Returns a list of user IDs that meet the inactivity condition


## Folder Structure
```InActiveLoginTracker/ 
├── InActiveLoginTracker.csproj 
├── InActiveUserLoginTracker.cs 
└── README.md
```

## Example Output

```Warning: User 6f1e4500 has a future login date. 
Warning: User 6f1e4502 has a future login date.
Warning: User 6f1e4503 has a future login date. 
Warning: User 6f1e4504 has a future login date. 
Warning: User 6f1e4505 has a future login date. 
Warning: User 6f1e4507 has a future login date. 
users with inActive login userIds: 6f1e4501
```

## How to Run

1. Navigate to the project directory:
   ```bash```
   ```cd InActiveLoginTracker```

2. Build and run the app:  
 - ```dotnet build```
 - ```dotnet run```

## What I Learned
- How to filter a list using custom conditions
- Working with ```DateTime``` comparison logic
- Defensive programming with null and future-date handling
- Writing readable, maintainable backend logic
- Real-world scenario implementation using lists, loops, and conditionals

## Next Steps
This logic could be extended to:
- [x] Identify inactive users based on last login
- [x] Write results to a file
- [ ] Accept user input from terminal
- [ ] Read users from a JSON/CSV source
- [ ] Extend to email notifications (mock/stub)
- [ ] Unit test core logic


## Extension: Writing To A File
 Next Step #2 
- This logic writes the filtered inactive users to a text file...

- Validate that the list is not null or empty
- Add a title and timestamp to the output
- Loop through user IDs and format each one (e.g., `- 6f1e4501`)
- Write the list to a file called `inactive-users-log.txt`
  - If the file exists, it appends
  - If not, it creates one

## Output

- File: `inactive-users-log.txt`
- Format:
```
   Inactive User IDs:
   Timestamp: 5/16/2025 7:51:37 PM
   6f1e4501
```
    

## What I Learned
- How to write to a file using File.AppendAllLines
- How to shape and format strings for readable logging
- How to validate inputs defensively
- The importance of logging and audit trails in backend systems

## Next Steps
Track enhancements and future improvements for this feature:
- [ ] Write output in `.csv` format for easier data processing
- [ ] Allow **user-specified filename** as input for flexibility
- [ ] Log **multiple batches** of inactive users with timestamps (append mode)
- [ ] Enable sending files via **email** or **upload to cloud storage** (e.g., S3 or Azure Blob)



## Author: 
Samuel Titiloye
[LinkedIn](https://www.linkedin.com/in/samueltitiloye/) | [GitHub](https://github.com/samuelotitiloye)