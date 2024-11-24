USE [AenDbEnterprise];
GO

DECLARE @Count INT = 1;
DECLARE @RandomMinutes INT;
DECLARE @CheckOutTime TIME;

WHILE @Count <= 46
BEGIN
    -- Generate a random minute offset for CheckOutTime between '17:00:00' and '23:00:00'
    SET @RandomMinutes = FLOOR(RAND() * (6 * 60));  -- Random minutes between 0 and 360 (6 hours)

    -- Calculate CheckOutTime as '17:00:00' + random minutes
    SET @CheckOutTime = CAST(DATEADD(MINUTE, @RandomMinutes, CAST('17:00:00' AS DATETIME)) AS TIME);

    -- Calculate WorkingHours as the difference between CheckInTime ('09:00:00') and the randomized CheckOutTime
    DECLARE @WorkingHours TIME = CAST(DATEADD(SECOND, 
                                DATEDIFF(SECOND, CAST('09:00:00' AS DATETIME), CAST(@CheckOutTime AS DATETIME)), 0) AS TIME);

    -- Calculate OverTimeHours as the difference between WorkingHours and RegularHours ('08:00:00')
    DECLARE @OverTimeHours TIME = CASE 
                                    WHEN @WorkingHours > '08:00:00' 
                                    THEN CAST(DATEADD(SECOND, 
                                        DATEDIFF(SECOND, CAST('08:00:00' AS DATETIME), CAST(@WorkingHours AS DATETIME)), 0) AS TIME)
                                    ELSE '00:00:00'
                                  END;

    -- Insert the row with calculated values
    INSERT INTO [dbo].[Attendances]
           ([Status]
           ,[CheckInTime]
           ,[CheckOutTime]
           ,[LeaveTypeId]
           ,[Remarks]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[EmployeeId]
           ,[RegularHours]
           ,[WorkingHours]
           ,[PiecesProduced]
           ,[OverTimeHours]
           ,[PayrollId])
     VALUES
           ('Present',                         -- Status
           '09:00:00',                          -- CheckInTime
           @CheckOutTime,                       -- Randomized CheckOutTime
           1,                                   -- LeaveTypeId
           'No remarks',                        -- Remarks
           GETDATE(),                           -- CreatedAt
           GETDATE(),                           -- UpdatedAt
           CASE WHEN @Count % 2 = 0 THEN 1 ELSE 2 END,  -- Alternate EmployeeId between 1 and 2
           '08:00:00',                          -- RegularHours
           @WorkingHours,                       -- Calculated WorkingHours
           NULL,                                -- PiecesProduced
           @OverTimeHours,                      -- Calculated OverTimeHours
           NULL);                               -- PayrollId

    SET @Count = @Count + 1;
END;
GO
