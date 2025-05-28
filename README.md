# Ap2-Modelagem-Software

Este projeto consiste no desenvolvimento de uma API RESTful para o gerenciamento de clínicas veterinárias, utilizando C#, .NET 6, Entity Framework Core e SQLite.

A aplicação permite o cadastro e controle de duas entidades principais:

- **Tutor**: responsável pelos pets.
- **Pet**: animal de estimação vinculado a um único tutor.

A relação entre as entidades é de **1:N**, ou seja, um tutor pode ter vários pets, mas cada pet está associado a apenas um tutor.

---

## Funcionalidades

- CRUD completo para **Tutores** e **Pets**.
- Consulta de tutores com seus respectivos pets.
- Consulta de pets com seus tutores.
- Validação de campos obrigatórios nas requisições.
- Prevenção de **serialização cíclica** com uso de DTOs.



## Video Explicativo

- https://drive.google.com/drive/folders/1S4O29QXD3HNUemNNjyi4Dp0PCjOr1ngN?usp=sharing