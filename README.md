# Avaliação Técnica – Desenvolvedor

Este repositório contém a solução da **Avaliação Técnica – Desenvolvedor**, com foco em lógica, interpretação de especificações e capacidade de resolver problemas utilizando **SQL** e **C#**.

---

## Tecnologias Utilizadas

* **SQL Server** (consulta SQL)
* **C# (.NET)**
* Estruturas de dados (árvores)

---

## Tarefa 1 – SQL

### Problema

Encontrar os colaboradores que possuem o **maior salário em cada departamento**.

### Estrutura das Tabelas

**Pessoa**

| Id | Nome  | Salario | DeptId |
| -- | ----- | ------- | ------ |
| 1  | Joe   | 70000   | 1      |
| 2  | Henry | 80000   | 2      |
| 3  | Sam   | 60000   | 2      |
| 4  | Max   | 90000   | 1      |

**Departamento**

| Id | Nome   |
| -- | ------ |
| 1  | TI     |
| 2  | Vendas |

### Solução em SQL

```sql
SELECT
    d.Nome AS Departamento,
    p.Nome AS Pessoa,
    p.Salario
FROM Pessoa p
INNER JOIN Departamento d ON d.Id = p.DeptId
WHERE p.Salario = (
    SELECT MAX(p2.Salario)
    FROM Pessoa p2
    WHERE p2.DeptId = p.DeptId
);
```

### Resultado Esperado

| Departamento | Pessoa | Salario |
| ------------ | ------ | ------- |
| TI           | Max    | 90000   |
| Vendas       | Henry  | 80000   |

---

## Tarefa 2 – Construção de Árvore

### Regras

* A **raiz** da árvore é o maior valor do array
* Subárvore da **esquerda**: números à esquerda da raiz no array, em ordem decrescente
* Subárvore da **direita**: números à direita da raiz no array, em ordem decrescente
* Array sem valores duplicados

---

## Implementação em C#
[Ver implementação da Tarefa 2 em C#](./src/TreeBuilder.cs)
