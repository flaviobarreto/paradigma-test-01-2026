-- =============================================
-- Avaliação Técnica Paradigma - Tarefa 1
-- SQL: Colaboradores com Maior Salário por Departamento
-- =============================================

-- Criação das tabelas de exemplo
CREATE TABLE Departamento (
    Id INT PRIMARY KEY,
    Nome VARCHAR(50)
);

CREATE TABLE Pessoa (
    Id INT PRIMARY KEY,
    Nome VARCHAR(50),
    Salario DECIMAL(10, 2),
    DeptId INT,
    FOREIGN KEY (DeptId) REFERENCES Departamento(Id)
);

-- Inserção de dados de exemplo
INSERT INTO Departamento (Id, Nome) VALUES
(1, 'TI'),
(2, 'Vendas');

INSERT INTO Pessoa (Id, Nome, Salario, DeptId) VALUES
(1, 'Joe', 70000, 1),
(2, 'Henry', 80000, 2),
(3, 'Sam', 60000, 2),
(4, 'Max', 90000, 1);

-- =============================================
-- SOLUÇÃO 1: Usando Window Function (ROW_NUMBER)
-- Mais eficiente e moderna
-- =============================================
SELECT 
    d.Nome AS Departamento,
    p.Nome AS Pessoa,
    p.Salario
FROM (
    SELECT 
        Id,
        Nome,
        Salario,
        DeptId,
        ROW_NUMBER() OVER (PARTITION BY DeptId ORDER BY Salario DESC) AS rn
    FROM Pessoa
) p
INNER JOIN Departamento d ON p.DeptId = d.Id
WHERE p.rn = 1
ORDER BY d.Nome;

-- =============================================
-- SOLUÇÃO 2: Usando Subquery com MAX
-- Alternativa clássica e bem compreendida
-- =============================================
SELECT 
    d.Nome AS Departamento,
    p.Nome AS Pessoa,
    p.Salario
FROM Pessoa p
INNER JOIN Departamento d ON p.DeptId = d.Id
INNER JOIN (
    SELECT DeptId, MAX(Salario) AS MaxSalario
    FROM Pessoa
    GROUP BY DeptId
) max_sal ON p.DeptId = max_sal.DeptId AND p.Salario = max_sal.MaxSalario
ORDER BY d.Nome;

-- =============================================
-- SOLUÇÃO 3: Usando CTE (Common Table Expression)
-- Mais legível e organizada
-- =============================================
WITH MaxSalariosPorDepto AS (
    SELECT 
        DeptId,
        MAX(Salario) AS MaxSalario
    FROM Pessoa
    GROUP BY DeptId
)
SELECT 
    d.Nome AS Departamento,
    p.Nome AS Pessoa,
    p.Salario
FROM Pessoa p
INNER JOIN Departamento d ON p.DeptId = d.Id
INNER JOIN MaxSalariosPorDepto ms ON p.DeptId = ms.DeptId AND p.Salario = ms.MaxSalario
ORDER BY d.Nome;

-- =============================================
-- RESULTADO ESPERADO:
-- =============================================
-- Departamento | Pessoa | Salario
-- -------------|--------|--------
-- TI           | Max    | 90000
-- Vendas       | Henry  | 80000
