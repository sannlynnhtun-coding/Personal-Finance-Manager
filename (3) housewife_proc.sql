USE housewife;
GO

CREATE PROCEDURE CheckBudgetAndBalance
    @Description VARCHAR(255),
    @FromToFlow VARCHAR(255),
    @CashFlow VARCHAR(25),
    @Amount DECIMAL(10,2),
    @Date DATE,
    @StatusCode INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DescriptionId INT;
    DECLARE @FromToFlowId INT;
    DECLARE @CashFlowId INT;
    DECLARE @ExpenseMonth DATE;
    DECLARE @BudgetAmount DECIMAL(10,2);
    DECLARE @TotalExpenses DECIMAL(10,2);

    -- Initialize status code to 0 (Success)
    SET @StatusCode = 0;

    -- Get the IDs for description, from_to_flow, user, and cash_flow from their corresponding tables
    SELECT @DescriptionId = id FROM descriptions WHERE description = @Description;
    SELECT @FromToFlowId = id FROM from_to_flow WHERE text = @FromToFlow;
    SELECT @CashFlowId = id FROM cash_flow WHERE text = @CashFlow;

    -- Check if there is an expenditure budget set for the specific month
    SET @ExpenseMonth = DATEFROMPARTS(YEAR(@Date), MONTH(@Date), 1);
    SELECT @BudgetAmount = amount FROM expenditure_budgets WHERE month = @ExpenseMonth;

    -- If no budget is set, set status code to 1 (Budget Not Set)
    IF @BudgetAmount IS NULL
    BEGIN
        SET @StatusCode = 1;
        RETURN;
    END

    -- Calculate the total expenses for the specific month
    SELECT @TotalExpenses = ISNULL(SUM(amount), 0)
    FROM expenses
    WHERE
    MONTH(date) = MONTH(@Date)
    AND YEAR(date) = YEAR(@Date);

    -- Calculate the total expenses including the new expense amount
    SET @TotalExpenses = @TotalExpenses + @Amount;

    -- Check if the total expenses exceed the budget amount
    IF @TotalExpenses > @BudgetAmount
    BEGIN
        -- Set status code to 2 (Exceed Budget)
        SET @StatusCode = 2;
        RETURN;
    END
END;

GO

CREATE PROCEDURE AddNewIncome
    @Description VARCHAR(255),
    @FromToFlow VARCHAR(255),
    @User VARCHAR(25),
    @CashFlow VARCHAR(25),
    @Amount DECIMAL(10,2),
    @Date DATE,
    @InsertedId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DescriptionId INT;
    DECLARE @FromToFlowId INT;
    DECLARE @UserId INT;
    DECLARE @CashFlowId INT;

    SELECT @DescriptionId = id FROM descriptions WHERE description = @Description;
    SELECT @FromToFlowId = id FROM from_to_flow WHERE text = @FromToFlow;
    SELECT @UserId = id FROM users WHERE name = @User;
    SELECT @CashFlowId = id FROM cash_flow WHERE text = @CashFlow;

    INSERT INTO incomes (description_id, from_to_flow_id, user_id, amount, cash_flow_id, date)
    VALUES (@DescriptionId, @FromToFlowId, @UserId, @Amount, @CashFlowId, @Date);

    SET @InsertedId = SCOPE_IDENTITY();

    SELECT @InsertedId AS InsertedId;
END;


GO

CREATE PROCEDURE AddNewExpense
    @Description VARCHAR(255),
    @FromToFlow VARCHAR(255),
    @User VARCHAR(25),
    @CashFlow VARCHAR(25),
    @Amount DECIMAL(10,2),
    @Date DATE,
    @InsertedId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DescriptionId INT;
    DECLARE @FromToFlowId INT;
    DECLARE @UserId INT;
    DECLARE @CashFlowId INT;

    SELECT @DescriptionId = id FROM descriptions WHERE description = @Description;
    SELECT @FromToFlowId = id FROM from_to_flow WHERE text = @FromToFlow;
    SELECT @UserId = id FROM users WHERE name = @User;
    SELECT @CashFlowId = id FROM cash_flow WHERE text = @CashFlow;

    INSERT INTO expenses (description_id, from_to_flow_id, user_id, amount, cash_flow_id, date)
    VALUES (@DescriptionId, @FromToFlowId, @UserId, @Amount, @CashFlowId, @Date);

    SET @InsertedId = SCOPE_IDENTITY();

    SELECT @InsertedId AS InsertedId;
END;

GO 

CREATE PROCEDURE AddNewSaving
    @Username VARCHAR(25),
    @Amount DECIMAL(10,2),
    @SavingMonth DATE,
    @StatusCode INT OUTPUT,
	@InsertedId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ExistingBalance DECIMAL(10,2);
	DECLARE @UserId INT ;

    SELECT @UserId = id FROM users WHERE username = @Username;

	SELECT @ExistingBalance = COALESCE((SELECT TOP 1 amount FROM balance), 0.00);

    IF @Amount > @ExistingBalance
    BEGIN
        SET @StatusCode = 2;
		RETURN;
    END
    ELSE
    BEGIN
		SET @StatusCode = 0;
		
        INSERT INTO saving (user_id, amount, saving_month)
        VALUES (@UserId, @Amount, @SavingMonth);
		
		SET @InsertedId = SCOPE_IDENTITY();    
    END
END;

GO

CREATE PROCEDURE Login
@username VARCHAR(25),
@password VARCHAR(50)
AS
BEGIN
	SELECT name,username,password FROM users WHERE username = @username AND password = HASHBYTES('sha2_256',@password);
END;

GO

CREATE PROCEDURE LoadUsers
AS
BEGIN
	SELECT username  from users;
END;

GO

CREATE PROCEDURE GetIncome
AS
BEGIN
	SELECT descriptions.description AS Description, from_to_flow.text AS [From], users.name AS Name, cash_flow.text AS Payment,incomes.amount AS Amount, incomes.date AS Date
	FROM incomes
	INNER JOIN descriptions ON incomes.description_id = descriptions.id
	INNER JOIN from_to_flow ON incomes.from_to_flow_id = from_to_flow.id
	INNER JOIN users ON incomes.user_id = users.id
	INNER JOIN cash_flow ON incomes.cash_flow_id = cash_flow.id
	WHERE MONTH(incomes.date) = MONTH(GETDATE()) AND YEAR(incomes.date) = YEAR(GETDATE());
END;

GO

CREATE PROCEDURE GetExpense
AS
BEGIN
	SELECT descriptions.description AS Description, from_to_flow.text AS [To], users.name AS Name, cash_flow.text AS Payment,expenses.amount AS Amount, expenses.date AS Date
	FROM expenses
	INNER JOIN descriptions ON expenses.description_id = descriptions.id
	INNER JOIN from_to_flow ON expenses.from_to_flow_id = from_to_flow.id
	INNER JOIN users ON expenses.user_id = users.id
	INNER JOIN cash_flow ON expenses.cash_flow_id = cash_flow.id
	WHERE MONTH(expenses.date) = MONTH(GETDATE()) AND YEAR(expenses.date) = YEAR(GETDATE());
END;

GO

CREATE PROCEDURE GetIncomeByMonth
@Year INT,
@Month INT
AS
BEGIN
	SELECT descriptions.description AS Description, from_to_flow.text AS [From], users.name AS Name, cash_flow.text AS Payment, incomes.amount AS Amount, incomes.date AS Date
	FROM incomes
	INNER JOIN descriptions ON incomes.description_id = descriptions.id
	INNER JOIN from_to_flow ON incomes.from_to_flow_id = from_to_flow.id
	INNER JOIN users ON incomes.user_id = users.id
	INNER JOIN cash_flow ON incomes.cash_flow_id = cash_flow.id
	WHERE YEAR(incomes.date) = @Year AND MONTH(incomes.date) = @Month;

END;

GO

CREATE PROCEDURE GetExpenseByMonth
@Year INT,
@Month INT
AS
BEGIN
	SELECT descriptions.description AS Description, from_to_flow.text AS [To], users.name AS Name, cash_flow.text AS Payment, expenses.amount AS Amount, expenses.date AS Date
	FROM expenses
	INNER JOIN descriptions ON expenses.description_id = descriptions.id
	INNER JOIN from_to_flow ON expenses.from_to_flow_id = from_to_flow.id
	INNER JOIN users ON expenses.user_id = users.id
	INNER JOIN cash_flow ON expenses.cash_flow_id = cash_flow.id
	WHERE YEAR(expenses.date) = @Year AND MONTH(expenses.date) = @Month;

END;

GO

CREATE PROCEDURE GetIncomeByUser
    @Username VARCHAR(25)
AS
BEGIN
    SELECT descriptions.description AS Description, from_to_flow.text AS [From], users.name AS Name, cash_flow.text AS Payment, incomes.amount AS Amount,  incomes.date AS Date
    FROM incomes
    INNER JOIN descriptions ON incomes.description_id = descriptions.id
    INNER JOIN from_to_flow ON incomes.from_to_flow_id = from_to_flow.id
    INNER JOIN users ON incomes.user_id = users.id
    INNER JOIN cash_flow ON incomes.cash_flow_id = cash_flow.id
    WHERE users.username LIKE '%' + @Username + '%';
END;

GO

CREATE PROCEDURE GetExpenseByUser
    @Username VARCHAR(25)
AS
BEGIN
    SELECT descriptions.description AS Description, from_to_flow.text AS [To], users.name AS Name, cash_flow.text AS Payment, expenses.amount AS Amount,  expenses.date AS Date
    FROM expenses
    INNER JOIN descriptions ON expenses.description_id = descriptions.id
    INNER JOIN from_to_flow ON expenses.from_to_flow_id = from_to_flow.id
    INNER JOIN users ON expenses.user_id = users.id
    INNER JOIN cash_flow ON expenses.cash_flow_id = cash_flow.id
    WHERE users.username LIKE '%' + @Username + '%';
END;

GO

CREATE PROCEDURE IncomeFormLoading
AS
BEGIN
	SELECT description FROM descriptions;
	SELECT text AS [From] FROM from_to_flow;
	SELECT text AS IncomeType FROM cash_flow;
END;

GO

CREATE PROCEDURE ExpenseFormLoading
AS
BEGIN
	SELECT description FROM descriptions;
	SELECT text AS [To] FROM from_to_flow;
	SELECT text AS Payment FROM cash_flow;
END;

GO

CREATE PROCEDURE InsertDescription
@name VARCHAR(255)
AS
BEGIN
	INSERT INTO descriptions(description) values(@name);
END;

GO

CREATE PROCEDURE InsertFromToFlow
@name VARCHAR(255)
AS
BEGIN
	INSERT INTO from_to_flow(text) values(@name);
END;

GO

CREATE PROCEDURE InsertCashFlow
@name VARCHAR(255)
AS
BEGIN
	INSERT INTO cash_flow(text) values(@name);
END;

GO

CREATE PROCEDURE LoadBalance
AS
BEGIN
	SELECT amount FROM balance;
END;

GO

CREATE PROCEDURE AddExpenditureBudget    
    @month DATE,
	@amount DECIMAL(10, 2),
    @insertedId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @balance DECIMAL(10, 2);
    SELECT @balance = amount FROM balance;
    IF @balance >= @amount
    BEGIN
        INSERT INTO expenditure_budgets (month, amount)
        VALUES (DATEFROMPARTS(YEAR(@month), MONTH(@month), 1), @amount);
        SET @insertedId = SCOPE_IDENTITY();

        SELECT id, month, amount
        FROM expenditure_budgets
        WHERE id = @insertedId;

        RETURN;
    END
    ELSE
    BEGIN
        THROW 51000, 'Your balance not enough for budget amount.', 1;
    END
END;

GO

CREATE PROCEDURE GetBudgetByYear
    @yearPattern VARCHAR(5) 
AS
BEGIN
    SET NOCOUNT ON;

    IF @yearPattern IS NULL
    BEGIN
        THROW 50000, 'Year pattern parameter cannot be null.', 1;
        RETURN;
    END

    SELECT 
        CAST(YEAR(month) AS VARCHAR(4)) + '-' + LEFT(DATENAME(MONTH, month), 3) AS [YearMonth],
        amount 
    FROM expenditure_budgets 
    WHERE CAST(YEAR(month) AS VARCHAR(4)) LIKE @yearPattern + '%'; -- Use the LIKE operator with the parameter
END;

GO

CREATE PROCEDURE GetBudgetByMonthOfCurrentYear
    @monthName VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @currentYear INT;
    SET @currentYear = YEAR(GETDATE());
    
    SELECT 
        CAST(@currentYear AS VARCHAR(4)) + '-' + LEFT(DATENAME(MONTH, month), 3) AS [YearMonth],
        amount 
    FROM expenditure_budgets 
    WHERE DATENAME(MONTH, month) LIKE @monthName + '%' AND YEAR(month) = @currentYear;
END;

GO

CREATE PROCEDURE LoadAllBudgets
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT FORMAT(month, 'yyyy-MMM') AS [Year-Month], amount AS Amount
    FROM expenditure_budgets;
END;

GO

CREATE PROCEDURE SavingLoad
@username VARCHAR(25)
AS
BEGIN
	DECLARE @user_id INT;
	SELECT @user_id = id FROM users WHERE username = @username;
	SELECT users.name AS [User], saving_month AS [Saving Month], amount AS Amount FROM saving
	INNER JOIN users on saving.user_id = users.id;
	SELECT ISNULL(amount,0) FROM total_saving;
END;

GO

CREATE PROCEDURE WithdrawSaving
    @username VARCHAR(25),
    @date DATE,
    @Amount DECIMAL(10,2)
AS
BEGIN
    DECLARE @user_id INT;
    DECLARE @existingSavingAmount DECIMAL(10,2);

    -- Get the user ID based on the username
    SELECT @user_id = id FROM users WHERE username = @username;

    -- Get the existing total saving amount
    SELECT @existingSavingAmount = amount FROM total_saving;

    -- Check if the withdrawal amount is less than or equal to the existing total saving amount
    IF @Amount <= @existingSavingAmount
    BEGIN
        -- Insert the withdrawal record into withdraw_saving table
        INSERT INTO withdraw_saving (user_id, date, amount)
        VALUES (@user_id, @date, @Amount);
    END
    ELSE
    BEGIN
        -- Throw an error if the withdrawal amount exceeds the existing total saving amount
        THROW 52000, 'Your withdrawal amount exceeds the existing total saving.', 1;
    END
END;

GO

CREATE PROCEDURE GetSavingByInsertedID
@InsertedId INT
AS
BEGIN
	SELECT users.name AS [User], saving_month AS [Saving Date], amount AS Amount FROM saving
	INNER JOIN users on saving.user_id = users.id
	WHERE saving.id = @InsertedId;
END;

GO

CREATE PROCEDURE GetSavingByYearly
@yearPattern VARCHAR(5)
AS
BEGIN
	SELECT users.name AS [User], CAST(YEAR(saving_month) AS VARCHAR(4)) + '-' + LEFT(DATENAME(MONTH, saving_month), 3) AS [YearAndMonth], amount AS Amount FROM saving
	INNER JOIN users ON saving.user_id = users.id
	WHERE CAST(YEAR(saving_month) AS VARCHAR(4)) LIKE @yearPattern + '%';
END;

GO

CREATE PROCEDURE GetSavingByMonthsOfCurrentYear
@monthName VARCHAR(20)
AS
BEGIN
	DECLARE @currentYear INT;
	SET @currentYear = YEAR(GETDATE());
	SELECT users.name AS [User], CAST(@currentYear AS VARCHAR(4)) + '-' + LEFT(DATENAME(MONTH, saving_month), 3) AS [YearAndMonth], amount AS Amount FROM saving
	INNER JOIN users ON saving.user_id = users.id
	WHERE DATENAME(MONTH, saving_month) LIKE @monthName + '%' AND YEAR(saving_month) = @currentYear;
END; 

GO

CREATE PROCEDURE GetTotalSaving
AS
BEGIN
    DECLARE @total DECIMAL(10, 2)

    SELECT @total = ISNULL(amount, 0.00) FROM total_saving;

    SELECT @total AS TotalSaving;
END;


GO

CREATE PROCEDURE GetwithdrawSavingByUser
@Name VARCHAR(25)
AS

BEGIN
	SELECT users.name AS [User], CAST(YEAR(date) AS VARCHAR(4)) + '-' + LEFT(DATENAME(MONTH, date), 3) AS [YearAndMonth],
	amount AS Amount FROM withdraw_saving
	INNER JOIN users ON withdraw_saving.user_id = users.id
	WHERE users.name LIKE @Name + '%';
END;

GO

CREATE PROCEDURE GetwithdrawByYearly
@withdrawyearPattern VARCHAR(4)
AS
BEGIN
	
	SELECT users.name AS [User], CAST(Year(date) AS VARCHAR(4)) + '-' + LEFT(DATENAME(MONTH,date),3) AS [YearAndMonth],
	amount AS WithdrawAmount FROM withdraw_saving
	INNER JOIN users ON withdraw_saving.user_id = users.id
	WHERE CAST(YEAR(date) AS VARCHAR(4)) LIKE @withdrawyearPattern + '%';
END;

GO

CREATE PROCEDURE GetWithdrawByCurrentYear
@withdrawMonth VARCHAR(20)
AS
BEGIN
	DECLARE @currentYear INT;
	SET @currentYear = YEAR(GETDATE());
	SELECT users.name AS [User], CAST(@currentYear AS VARCHAR(4)) + '-' + LEFT(DATENAME(MONTH, date), 3) AS [YearAndMonth], amount AS Amount FROM withdraw_saving
	INNER JOIN users ON withdraw_saving.user_id = users.id
	WHERE DATENAME(MONTH, date) LIKE @withdrawMonth + '%' AND YEAR(date) = @currentYear;
END;

GO


CREATE PROCEDURE AddNewWithdrawSaving
@userName VARCHAR(25),
@Amount DECIMAL(10,2),
@InsertedId INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @TotalSaving DECIMAL(10, 2);
    DECLARE @WithdrawAmount DECIMAL(10, 2);

    SELECT @TotalSaving = amount FROM total_saving;
    SET @WithdrawAmount = @Amount;

    IF @TotalSaving < @WithdrawAmount
    BEGIN
        RAISERROR ('Insufficient balance for withdrawal.', 16, 1);
		RETURN;
    END
	ELSE
	BEGIN
	DECLARE @user_id INT;
	DECLARE @date DATE;
	SELECT @user_id = id FROM users WHERE name = @userName;
	SET @date = CONVERT(DATE,GETDATE());
	
	INSERT INTO withdraw_saving(user_id, date, amount) VALUES(@user_id, @date,@Amount);
	SET @InsertedId = SCOPE_IDENTITY();
	END;
END;
-- Reporting Procedures
GO

CREATE PROCEDURE GetIncomeTypeAverageByYearly
AS
BEGIN
    DECLARE @TopIncomeType INT;

    -- Find the top income type over the last 5 years
    WITH TopIncomeTypes AS (
        SELECT TOP 1 WITH TIES
            I.description_id,
            COUNT(*) AS IncomeTypeCount
        FROM
            incomes I
        WHERE
            YEAR(I.date) >= YEAR(DATEADD(YEAR, -5, GETDATE())) -- Select data from the last 5 years
        GROUP BY
            I.description_id
        ORDER BY
            COUNT(*) DESC
    )
    SELECT TOP 1
        @TopIncomeType = description_id
    FROM
        TopIncomeTypes;

    -- Retrieve the count of the top income type for each year
    WITH YearlyIncomeCounts AS (
        SELECT
            YEAR(I.date) AS Year,
            COUNT(*) AS IncomeCount
        FROM
            incomes I
        WHERE
            YEAR(I.date) >= YEAR(DATEADD(YEAR, -5, GETDATE())) -- Select data from the last 5 years
            AND I.description_id = @TopIncomeType
        GROUP BY
            YEAR(I.date)
    ),
    AllYears AS (
        SELECT YEAR(GETDATE()) - 4 AS Year -- Get the year 5 years ago
        UNION ALL
        SELECT Year + 1 FROM AllYears WHERE Year < YEAR(GETDATE()) -- Generate years from 5 years ago to the current year
    )
    SELECT
        AllYears.Year,
        (SELECT description FROM descriptions WHERE id = @TopIncomeType) AS TopIncomeType,
        ISNULL(IncomeCount, 0) AS IncomeCount
    FROM
        AllYears
    LEFT JOIN
        YearlyIncomeCounts ON AllYears.Year = YearlyIncomeCounts.Year
    ORDER BY
        AllYears.Year;
END;

GO

CREATE PROCEDURE GetIncomeTypeAverageByMonthly
AS
BEGIN
    -- Declare variables
    DECLARE @TopIncomeType INT;

    -- Find the top income type for the current year
    WITH TopIncomeTypes AS (
        SELECT TOP 1 WITH TIES
            I.description_id,
            COUNT(*) AS IncomeTypeCount
        FROM
            incomes I
        WHERE
            YEAR(I.date) = YEAR(GETDATE()) -- Select data for the current year
        GROUP BY
            I.description_id
        ORDER BY
            COUNT(*) DESC
    )
    SELECT TOP 1
        @TopIncomeType = description_id
    FROM
        TopIncomeTypes;

    -- Generate numbers for months
    ;WITH Months AS (
        SELECT 1 AS MonthNumber
        UNION ALL
        SELECT MonthNumber + 1 FROM Months WHERE MonthNumber < 12
    ),
    -- Retrieve the count of the top income type for each month of the current year
    MonthlyIncomeCounts AS (
        SELECT
            MonthNumber,
            DATENAME(MONTH, DATEADD(MONTH, MonthNumber - 1, DATEFROMPARTS(YEAR(GETDATE()), 1, 1))) AS MonthName,
            COUNT(I.id) AS IncomeCount
        FROM
            Months
        LEFT JOIN
            incomes I ON MONTH(I.date) = MonthNumber AND YEAR(I.date) = YEAR(GETDATE())
                       AND I.description_id = @TopIncomeType
        GROUP BY
            MonthNumber
    )
    SELECT
        MonthlyIncomeCounts.MonthName,
        (SELECT description FROM descriptions WHERE id = @TopIncomeType) AS TopIncomeType,
        COALESCE(MonthlyIncomeCounts.IncomeCount, 0) AS IncomeCount
    FROM
        MonthlyIncomeCounts
    ORDER BY
        MONTH(DATEFROMPARTS(YEAR(GETDATE()), MonthNumber, 1));
END;

GO

CREATE PROCEDURE GetIncomeSourceAverageByYearly
AS
BEGIN
    DECLARE @TopIncomeType INT;

    -- Find the top income type over the last 5 years
    ;WITH TopIncomeTypes AS (
        SELECT TOP 1 WITH TIES
            I.description_id,
            COUNT(*) AS IncomeTypeCount
        FROM
            incomes I
        WHERE
            YEAR(I.date) >= YEAR(DATEADD(YEAR, -5, GETDATE())) -- Select data from the last 5 years
        GROUP BY
            I.description_id
        ORDER BY
            COUNT(*) DESC
    )
    SELECT TOP 1
        @TopIncomeType = description_id
    FROM
        TopIncomeTypes;

    -- Check if the income source exists in from_to_flow, if not, insert it
    IF NOT EXISTS (SELECT 1 FROM from_to_flow WHERE [text] = (SELECT description FROM descriptions WHERE id = @TopIncomeType))
    BEGIN
        INSERT INTO from_to_flow ([text])
        SELECT description FROM descriptions WHERE id = @TopIncomeType;
    END

    -- Retrieve the count of the top income type for each year
    ;WITH YearlyIncomeCounts AS (
        SELECT
            YEAR(I.date) AS Year,
            COUNT(*) AS IncomeCount
        FROM
            incomes I
        WHERE
            YEAR(I.date) >= YEAR(DATEADD(YEAR, -5, GETDATE())) -- Select data from the last 5 years
            AND I.description_id = @TopIncomeType
        GROUP BY
            YEAR(I.date)
    ),
    AllYears AS (
        SELECT YEAR(GETDATE()) - 4 AS Year -- Get the year 5 years ago
        UNION ALL
        SELECT Year + 1 FROM AllYears WHERE Year < YEAR(GETDATE()) -- Generate years from 5 years ago to the current year
    )
    SELECT
        AllYears.Year,
        (SELECT [text] FROM from_to_flow WHERE id = @TopIncomeType) AS TopIncomeSource, -- Changed to use from_to_flow instead of descriptions
        ISNULL(IncomeCount, 0) AS IncomeCount
    FROM
        AllYears
    LEFT JOIN
        YearlyIncomeCounts ON AllYears.Year = YearlyIncomeCounts.Year
    ORDER BY
        AllYears.Year;
END;

GO

CREATE PROCEDURE GetIncomeSourceAverageByMonthly
AS
BEGIN
    -- Declare variables
    DECLARE @TopIncomeSource INT;

    -- Find the top income source for the current year
    WITH TopIncomeSources AS (
        SELECT TOP 1 WITH TIES
            I.from_to_flow_id,
            COUNT(*) AS IncomeSourceCount
        FROM
            incomes I
        WHERE
            YEAR(I.date) = YEAR(GETDATE()) -- Select data for the current year
        GROUP BY
            I.from_to_flow_id
        ORDER BY
            COUNT(*) DESC
    )
    SELECT TOP 1
        @TopIncomeSource = from_to_flow_id
    FROM
        TopIncomeSources;

    -- Check if the income source exists in from_to_flow, if not, insert it
    IF NOT EXISTS (SELECT 1 FROM from_to_flow WHERE id = @TopIncomeSource)
    BEGIN
        DECLARE @IncomeSourceText VARCHAR(255);
        SELECT @IncomeSourceText = [text] FROM from_to_flow WHERE id = @TopIncomeSource;
        INSERT INTO from_to_flow ([text]) VALUES (@IncomeSourceText);
    END

    -- Generate numbers for months
    ;WITH Months AS (
        SELECT 1 AS MonthNumber
        UNION ALL
        SELECT MonthNumber + 1 FROM Months WHERE MonthNumber < 12
    ),
    -- Retrieve the count of the top income source for each month of the current year
    MonthlyIncomeSourceCounts AS (
        SELECT
            MonthNumber,
            DATENAME(MONTH, DATEADD(MONTH, MonthNumber - 1, DATEFROMPARTS(YEAR(GETDATE()), 1, 1))) AS MonthName,
            COUNT(I.id) AS IncomeCount
        FROM
            Months
        LEFT JOIN
            incomes I ON MONTH(I.date) = MonthNumber AND YEAR(I.date) = YEAR(GETDATE())
                       AND I.from_to_flow_id = @TopIncomeSource
        GROUP BY
            MonthNumber
    )
    SELECT
        MonthlyIncomeSourceCounts.MonthName,
        (SELECT [text] FROM from_to_flow WHERE id = @TopIncomeSource) AS TopIncomeSource,
        COALESCE(MonthlyIncomeSourceCounts.IncomeCount, 0) AS IncomeCount
    FROM
        MonthlyIncomeSourceCounts
    ORDER BY
        MONTH(DATEFROMPARTS(YEAR(GETDATE()), MonthNumber, 1));
END;

GO

CREATE PROCEDURE GetPaymentMethodAverageByYearly
AS
BEGIN
    -- Declare variables
    DECLARE @TopPaymentMethod INT;

    -- Find the top payment method over the last 5 years
    ;WITH TopPaymentMethods AS (
        SELECT TOP 1 WITH TIES
            I.cash_flow_id,
            COUNT(*) AS PaymentMethodCount
        FROM
            incomes I
        WHERE
            YEAR(I.date) >= YEAR(DATEADD(YEAR, -5, GETDATE())) -- Select data from the last 5 years
        GROUP BY
            I.cash_flow_id
        ORDER BY
            COUNT(*) DESC
    )
    SELECT TOP 1
        @TopPaymentMethod = cash_flow_id
    FROM
        TopPaymentMethods;

    -- Check if the payment method exists in cash_flow, if not, insert it
    IF NOT EXISTS (SELECT 1 FROM cash_flow WHERE id = @TopPaymentMethod)
    BEGIN
        INSERT INTO cash_flow ([text])
        SELECT text FROM from_to_flow WHERE id = @TopPaymentMethod;
    END

    -- Retrieve the count of the top payment method for each year
    ;WITH YearlyPaymentCounts AS (
        SELECT
            YEAR(I.date) AS Year,
            COUNT(*) AS PaymentCount
        FROM
            incomes I
        WHERE
            YEAR(I.date) >= YEAR(DATEADD(YEAR, -5, GETDATE())) -- Select data from the last 5 years
            AND I.cash_flow_id = @TopPaymentMethod
        GROUP BY
            YEAR(I.date)
    ),
    AllYears AS (
        SELECT YEAR(GETDATE()) - 4 AS Year -- Get the year 5 years ago
        UNION ALL
        SELECT Year + 1 FROM AllYears WHERE Year < YEAR(GETDATE()) -- Generate years from 5 years ago to the current year
    )
    SELECT
        AllYears.Year,
        (SELECT [text] FROM cash_flow WHERE id = @TopPaymentMethod) AS TopPaymentMethod,
        ISNULL(PaymentCount, 0) AS PaymentCount
    FROM
        AllYears
    LEFT JOIN
        YearlyPaymentCounts ON AllYears.Year = YearlyPaymentCounts.Year
    ORDER BY
        AllYears.Year;
END;

GO

CREATE PROCEDURE GetPaymentMethodAverageByMonthly
AS
BEGIN
    -- Declare variables
    DECLARE @TopPaymentMethod INT;

    -- Find the top payment method for the current year
    WITH TopPaymentMethods AS (
        SELECT TOP 1 WITH TIES
            I.cash_flow_id,
            COUNT(*) AS PaymentMethodCount
        FROM
            incomes I
        WHERE
            YEAR(I.date) = YEAR(GETDATE()) -- Select data for the current year
        GROUP BY
            I.cash_flow_id
        ORDER BY
            COUNT(*) DESC
    )
    SELECT TOP 1
        @TopPaymentMethod = cash_flow_id
    FROM
        TopPaymentMethods;

    -- Check if the payment method exists in cash_flow, if not, insert it
    IF NOT EXISTS (SELECT 1 FROM cash_flow WHERE id = @TopPaymentMethod)
    BEGIN
        DECLARE @PaymentMethodText VARCHAR(25);
        SELECT @PaymentMethodText = [text] FROM cash_flow WHERE id = @TopPaymentMethod;
        INSERT INTO cash_flow ([text]) VALUES (@PaymentMethodText);
    END

    -- Generate numbers for months
    ;WITH Months AS (
        SELECT 1 AS MonthNumber
        UNION ALL
        SELECT MonthNumber + 1 FROM Months WHERE MonthNumber < 12
    ),
    -- Retrieve the count of the top payment method for each month of the current year
    MonthlyPaymentMethodCounts AS (
        SELECT
            MonthNumber,
            DATENAME(MONTH, DATEADD(MONTH, MonthNumber - 1, DATEFROMPARTS(YEAR(GETDATE()), 1, 1))) AS MonthName,
            COUNT(I.id) AS PaymentCount
        FROM
            Months
        LEFT JOIN
            incomes I ON MONTH(I.date) = MonthNumber AND YEAR(I.date) = YEAR(GETDATE())
                       AND I.cash_flow_id = @TopPaymentMethod
        GROUP BY
            MonthNumber
    )
    SELECT
        MonthlyPaymentMethodCounts.MonthName,
        (SELECT [text] FROM cash_flow WHERE id = @TopPaymentMethod) AS TopPaymentMethod,
        COALESCE(MonthlyPaymentMethodCounts.PaymentCount, 0) AS PaymentCount
    FROM
        MonthlyPaymentMethodCounts
    ORDER BY
        MONTH(DATEFROMPARTS(YEAR(GETDATE()), MonthNumber, 1));
END;

GO

CREATE PROCEDURE GetExpenseTypeAverageByYearly
AS
BEGIN
    DECLARE @TopExpenseType INT;

    -- Find the top expense type over the last 5 years
    WITH TopExpenseTypes AS (
        SELECT TOP 1 WITH TIES
            E.description_id,
            COUNT(*) AS ExpenseTypeCount
        FROM
            expenses E
        WHERE
            YEAR(E.date) >= YEAR(DATEADD(YEAR, -5, GETDATE())) -- Select data from the last 5 years
        GROUP BY
            E.description_id
        ORDER BY
            COUNT(*) DESC
    )
    SELECT TOP 1
        @TopExpenseType = description_id
    FROM
        TopExpenseTypes;

    -- Retrieve the count of the top expense type for each year
    WITH YearlyExpenseCounts AS (
        SELECT
            YEAR(E.date) AS Year,
            COUNT(*) AS ExpenseCount
        FROM
            expenses E
        WHERE
            YEAR(E.date) >= YEAR(DATEADD(YEAR, -5, GETDATE())) -- Select data from the last 5 years
            AND E.description_id = @TopExpenseType
        GROUP BY
            YEAR(E.date)
    ),
    AllYears AS (
        SELECT YEAR(GETDATE()) - 4 AS Year -- Get the year 5 years ago
        UNION ALL
        SELECT Year + 1 FROM AllYears WHERE Year < YEAR(GETDATE()) -- Generate years from 5 years ago to the current year
    )
    SELECT
        AllYears.Year,
        (SELECT description FROM descriptions WHERE id = @TopExpenseType) AS TopExpenseType,
        ISNULL(ExpenseCount, 0) AS ExpenseCount
    FROM
        AllYears
    LEFT JOIN
        YearlyExpenseCounts ON AllYears.Year = YearlyExpenseCounts.Year
    ORDER BY
        AllYears.Year;
END;

GO

CREATE PROCEDURE GetExpenseTypeAverageByMonthly
AS
BEGIN
    -- Declare variables
    DECLARE @TopExpenseType INT;

    -- Find the top expense type for the current year
    WITH TopExpenseTypes AS (
        SELECT TOP 1 WITH TIES
            E.description_id,
            COUNT(*) AS ExpenseTypeCount
        FROM
            expenses E
        WHERE
            YEAR(E.date) = YEAR(GETDATE()) -- Select data for the current year
        GROUP BY
            E.description_id
        ORDER BY
            COUNT(*) DESC
    )
    SELECT TOP 1
        @TopExpenseType = description_id
    FROM
        TopExpenseTypes;

    -- Generate numbers for months
    ;WITH Months AS (
        SELECT 1 AS MonthNumber
        UNION ALL
        SELECT MonthNumber + 1 FROM Months WHERE MonthNumber < 12
    ),
    -- Retrieve the count of the top expense type for each month of the current year
    MonthlyExpenseCounts AS (
        SELECT
            MonthNumber,
            DATENAME(MONTH, DATEADD(MONTH, MonthNumber - 1, DATEFROMPARTS(YEAR(GETDATE()), 1, 1))) AS MonthName,
            COUNT(E.id) AS ExpenseCount
        FROM
            Months
        LEFT JOIN
            expenses E ON MONTH(E.date) = MonthNumber AND YEAR(E.date) = YEAR(GETDATE())
                       AND E.description_id = @TopExpenseType
        GROUP BY
            MonthNumber
    )
    SELECT
        MonthlyExpenseCounts.MonthName,
        (SELECT description FROM descriptions WHERE id = @TopExpenseType) AS TopExpenseType,
        COALESCE(MonthlyExpenseCounts.ExpenseCount, 0) AS ExpenseCount
    FROM
        MonthlyExpenseCounts
    ORDER BY
        MONTH(DATEFROMPARTS(YEAR(GETDATE()), MonthNumber, 1));
END;

GO

CREATE PROCEDURE GetExpenseDestinationAverageByYearly
AS
BEGIN
    DECLARE @TopExpenseType INT;

    -- Find the top expense type over the last 5 years
    ;WITH TopExpenseTypes AS (
        SELECT TOP 1 WITH TIES
            E.description_id,
            COUNT(*) AS ExpenseTypeCount
        FROM
            expenses E
        WHERE
            YEAR(E.date) >= YEAR(DATEADD(YEAR, -5, GETDATE())) -- Select data from the last 5 years
        GROUP BY
            E.description_id
        ORDER BY
            COUNT(*) DESC
    )
    SELECT TOP 1
        @TopExpenseType = description_id
    FROM
        TopExpenseTypes;

    -- Check if the expense destination exists in from_to_flow, if not, insert it
    IF NOT EXISTS (SELECT 1 FROM from_to_flow WHERE [text] = (SELECT description FROM descriptions WHERE id = @TopExpenseType))
    BEGIN
        INSERT INTO from_to_flow ([text])
        SELECT description FROM descriptions WHERE id = @TopExpenseType;
    END

    -- Retrieve the count of the top expense destination for each year
    ;WITH YearlyExpenseCounts AS (
        SELECT
            YEAR(E.date) AS Year,
            COUNT(*) AS ExpenseCount
        FROM
            expenses E
        WHERE
            YEAR(E.date) >= YEAR(DATEADD(YEAR, -5, GETDATE())) -- Select data from the last 5 years
            AND E.description_id = @TopExpenseType
        GROUP BY
            YEAR(E.date)
    ),
    AllYears AS (
        SELECT YEAR(GETDATE()) - 4 AS Year -- Get the year 5 years ago
        UNION ALL
        SELECT Year + 1 FROM AllYears WHERE Year < YEAR(GETDATE()) -- Generate years from 5 years ago to the current year
    )
    SELECT
        AllYears.Year,
        (SELECT [text] FROM from_to_flow WHERE id = @TopExpenseType) AS TopExpenseDestination,
        ISNULL(ExpenseCount, 0) AS ExpenseCount
    FROM
        AllYears
    LEFT JOIN
        YearlyExpenseCounts ON AllYears.Year = YearlyExpenseCounts.Year
    ORDER BY
        AllYears.Year;
END;

GO

CREATE PROCEDURE GetExpenseDestinationAverageByMonthly
AS
BEGIN
    -- Declare variables
    DECLARE @TopExpenseDestination INT;

    -- Find the top expense destination for the current year
    WITH TopExpenseDestinations AS (
        SELECT TOP 1 WITH TIES
            E.from_to_flow_id,
            COUNT(*) AS ExpenseDestinationCount
        FROM
            expenses E
        WHERE
            YEAR(E.date) = YEAR(GETDATE()) -- Select data for the current year
        GROUP BY
            E.from_to_flow_id
        ORDER BY
            COUNT(*) DESC
    )
    SELECT TOP 1
        @TopExpenseDestination = from_to_flow_id
    FROM
        TopExpenseDestinations;

    -- Check if the expense destination exists in from_to_flow, if not, insert it
    IF NOT EXISTS (SELECT 1 FROM from_to_flow WHERE id = @TopExpenseDestination)
    BEGIN
        DECLARE @ExpenseDestinationText VARCHAR(255);
        SELECT @ExpenseDestinationText = [text] FROM from_to_flow WHERE id = @TopExpenseDestination;
        INSERT INTO from_to_flow ([text]) VALUES (@ExpenseDestinationText);
    END

    -- Generate numbers for months
    ;WITH Months AS (
        SELECT 1 AS MonthNumber
        UNION ALL
        SELECT MonthNumber + 1 FROM Months WHERE MonthNumber < 12
    ),
    -- Retrieve the count of the top expense destination for each month of the current year
    MonthlyExpenseDestinationCounts AS (
        SELECT
            MonthNumber,
            DATENAME(MONTH, DATEADD(MONTH, MonthNumber - 1, DATEFROMPARTS(YEAR(GETDATE()), 1, 1))) AS MonthName,
            COUNT(E.id) AS ExpenseCount
        FROM
            Months
        LEFT JOIN
            expenses E ON MONTH(E.date) = MonthNumber AND YEAR(E.date) = YEAR(GETDATE())
                       AND E.from_to_flow_id = @TopExpenseDestination
        GROUP BY
            MonthNumber
    )
    SELECT
        MonthlyExpenseDestinationCounts.MonthName,
        (SELECT [text] FROM from_to_flow WHERE id = @TopExpenseDestination) AS TopExpenseDestination,
        COALESCE(MonthlyExpenseDestinationCounts.ExpenseCount, 0) AS ExpenseCount
    FROM
        MonthlyExpenseDestinationCounts
    ORDER BY
        MONTH(DATEFROMPARTS(YEAR(GETDATE()), MonthNumber, 1));
END;

GO

CREATE PROCEDURE GetExpensePaymentMethodAverageByYearly
AS
BEGIN
    -- Declare variables
    DECLARE @TopPaymentMethod INT;

    -- Find the top payment method for expenses over the last 5 years
    ;WITH TopPaymentMethods AS (
        SELECT TOP 1 WITH TIES
            E.cash_flow_id,
            COUNT(*) AS PaymentMethodCount
        FROM
            expenses E
        WHERE
            YEAR(E.date) >= YEAR(DATEADD(YEAR, -5, GETDATE())) -- Select data from the last 5 years
        GROUP BY
            E.cash_flow_id
        ORDER BY
            COUNT(*) DESC
    )
    SELECT TOP 1
        @TopPaymentMethod = cash_flow_id
    FROM
        TopPaymentMethods;

    -- Check if the payment method exists in cash_flow, if not, insert it
    IF NOT EXISTS (SELECT 1 FROM cash_flow WHERE id = @TopPaymentMethod)
    BEGIN
        INSERT INTO cash_flow ([text])
        SELECT text FROM from_to_flow WHERE id = @TopPaymentMethod;
    END

    -- Retrieve the count of the top payment method for expenses for each year
    ;WITH YearlyPaymentCounts AS (
        SELECT
            YEAR(E.date) AS Year,
            COUNT(*) AS PaymentCount
        FROM
            expenses E
        WHERE
            YEAR(E.date) >= YEAR(DATEADD(YEAR, -5, GETDATE())) -- Select data from the last 5 years
            AND E.cash_flow_id = @TopPaymentMethod
        GROUP BY
            YEAR(E.date)
    ),
    AllYears AS (
        SELECT YEAR(GETDATE()) - 4 AS Year -- Get the year 5 years ago
        UNION ALL
        SELECT Year + 1 FROM AllYears WHERE Year < YEAR(GETDATE()) -- Generate years from 5 years ago to the current year
    )
    SELECT
        AllYears.Year,
        (SELECT [text] FROM cash_flow WHERE id = @TopPaymentMethod) AS TopPaymentMethod,
        ISNULL(PaymentCount, 0) AS PaymentCount
    FROM
        AllYears
    LEFT JOIN
        YearlyPaymentCounts ON AllYears.Year = YearlyPaymentCounts.Year
    ORDER BY
        AllYears.Year;
END;

GO

CREATE PROCEDURE GetExpensePaymentMethodAverageByMonthly
AS
BEGIN
    -- Declare variables
    DECLARE @TopPaymentMethod INT;

    -- Find the top payment method for expenses for the current year
    WITH TopPaymentMethods AS (
        SELECT TOP 1 WITH TIES
            E.cash_flow_id,
            COUNT(*) AS PaymentMethodCount
        FROM
            expenses E
        WHERE
            YEAR(E.date) = YEAR(GETDATE()) -- Select data for the current year
        GROUP BY
            E.cash_flow_id
        ORDER BY
            COUNT(*) DESC
    )
    SELECT TOP 1
        @TopPaymentMethod = cash_flow_id
    FROM
        TopPaymentMethods;

    -- Check if the payment method exists in cash_flow, if not, insert it
    IF NOT EXISTS (SELECT 1 FROM cash_flow WHERE id = @TopPaymentMethod)
    BEGIN
        DECLARE @PaymentMethodText VARCHAR(25);
        SELECT @PaymentMethodText = [text] FROM cash_flow WHERE id = @TopPaymentMethod;
        INSERT INTO cash_flow ([text]) VALUES (@PaymentMethodText);
    END

    -- Generate numbers for months
    ;WITH Months AS (
        SELECT 1 AS MonthNumber
        UNION ALL
        SELECT MonthNumber + 1 FROM Months WHERE MonthNumber < 12
    ),
    -- Retrieve the count of the top payment method for expenses for each month of the current year
    MonthlyPaymentMethodCounts AS (
        SELECT
            MonthNumber,
            DATENAME(MONTH, DATEADD(MONTH, MonthNumber - 1, DATEFROMPARTS(YEAR(GETDATE()), 1, 1))) AS MonthName,
            COUNT(E.id) AS PaymentCount
        FROM
            Months
        LEFT JOIN
            expenses E ON MONTH(E.date) = MonthNumber AND YEAR(E.date) = YEAR(GETDATE())
                       AND E.cash_flow_id = @TopPaymentMethod
        GROUP BY
            MonthNumber
    )
    SELECT
        MonthlyPaymentMethodCounts.MonthName,
        (SELECT [text] FROM cash_flow WHERE id = @TopPaymentMethod) AS TopPaymentMethod,
        COALESCE(MonthlyPaymentMethodCounts.PaymentCount, 0) AS PaymentCount
    FROM
        MonthlyPaymentMethodCounts
    ORDER BY
        MONTH(DATEFROMPARTS(YEAR(GETDATE()), MonthNumber, 1));
END;

GO

CREATE PROCEDURE GetExceedingBudgetMonthsByYearly
AS
BEGIN
    -- Declare variables
    DECLARE @CurrentYear INT = YEAR(GETDATE());
    DECLARE @LoopYear INT = @CurrentYear - 5;

    -- Create a temporary table to store the results
    CREATE TABLE #ExceedingBudgetMonths (
        Year INT,
        Month VARCHAR(3),
        Budget DECIMAL(10, 2),
        TotalExpense DECIMAL(10, 2)
    );

    -- Loop through the last 5 years
    WHILE @LoopYear <= @CurrentYear
    BEGIN
        DECLARE @LoopMonth INT = 1;
        WHILE @LoopMonth <= 12
        BEGIN
            INSERT INTO #ExceedingBudgetMonths (Year, Month, Budget, TotalExpense)
            SELECT 
                YEAR(E.date) AS Year,
                LEFT(DATENAME(MONTH, DATEFROMPARTS(YEAR(E.date), @LoopMonth, 1)), 3) AS Month,
                B.amount AS Budget,
                COALESCE(SUM(E.amount), 0) AS TotalExpense
            FROM 
                expenditure_budgets B
            LEFT JOIN 
                expenses E ON YEAR(E.date) = @LoopYear AND MONTH(E.date) = @LoopMonth
            WHERE 
                YEAR(B.month) = @LoopYear AND MONTH(B.month) = @LoopMonth
            GROUP BY 
                YEAR(E.date), MONTH(E.date), B.amount
            HAVING 
                COALESCE(SUM(E.amount), 0) > B.amount;

            SET @LoopMonth = @LoopMonth + 1;
        END

        SET @LoopYear = @LoopYear + 1;
    END

    -- Select the results
    SELECT * FROM #ExceedingBudgetMonths;

    -- Drop the temporary table
    DROP TABLE #ExceedingBudgetMonths;
END;

GO

CREATE PROCEDURE GetCurrentYearExceedingBudgetMonths
AS
BEGIN
    -- Create a temporary table to store the results
    CREATE TABLE #ExceedingBudgetMonths (
        Month VARCHAR(3),
        Budget DECIMAL(10, 2),
        TotalExpense DECIMAL(10, 2)
    );

    -- Loop through the months of the current year
    DECLARE @LoopMonth INT = 1;
    WHILE @LoopMonth <= 12
    BEGIN
        INSERT INTO #ExceedingBudgetMonths (Month, Budget, TotalExpense)
        SELECT 
            LEFT(DATENAME(MONTH, DATEFROMPARTS(YEAR(GETDATE()), @LoopMonth, 1)), 3) AS Month,
            B.amount AS Budget,
            COALESCE(SUM(E.amount), 0) AS TotalExpense
        FROM 
            expenditure_budgets B
        LEFT JOIN 
            expenses E ON YEAR(E.date) = YEAR(GETDATE()) AND MONTH(E.date) = @LoopMonth
        WHERE 
            YEAR(B.month) = YEAR(GETDATE()) AND MONTH(B.month) = @LoopMonth
        GROUP BY 
            MONTH(E.date), B.amount
        HAVING 
            COALESCE(SUM(E.amount), 0) > B.amount;

        SET @LoopMonth = @LoopMonth + 1;
    END

    -- Select the results
    SELECT * FROM #ExceedingBudgetMonths;

    -- Drop the temporary table
    DROP TABLE #ExceedingBudgetMonths;
END;












