### Desafio de Desenvolvimento de API de Pokémons

Bem-vindo ao Desafio de Desenvolvimento de API de Pokémons! Seu objetivo é criar uma API RESTful que forneça informações sobre Pokémons e atenda aos seguintes requisitos:

### Requisitos Funcionais:

1. *Endpoint para Buscar um Pokémon pelo Nome:*
   - Crie um endpoint /api/pokemon/{nome} que permita aos usuários buscar um Pokémon pelo seu nome.
   - Quando um Pokémon é buscado pelo nome, o número de vezes que ele foi pesquisado deve ser registrado no banco de dados.

2. *Endpoint para Retornar os 10 Pokémons Mais Famosos:*
   - Implemente um endpoint /api/pokemon/famous que retorne os 10 Pokémons mais famosos com base no número de vezes que foram pesquisados pelo nome.

### Requisitos Não Funcionais:

1. *Cobertura de Testes Unitários:*
   - Garanta que sua aplicação tenha uma cobertura de testes unitários de pelo menos 80%.

2. *Utilização do Redis:*
   - Utilize o Redis para armazenar informações sobre os Pokémons pesquisados e o número de vezes que foram buscados.

3. *Utilização de Docker Compose para o Banco de Dados:*
   - Utilize o Docker Compose para configurar e executar o banco de dados usado pela aplicação.

### Regras de Negócio Adicionais:

1. *Registro de Buscas de Pokémon:*
   - Cada vez que um Pokémon é buscado pelo nome, registre essa busca no banco de dados, incrementando o contador de vezes que ele foi pesquisado.

2. *Cálculo dos Pokémons Mais Famosos:*
   - Para determinar os Pokémons mais famosos, consulte o banco de dados e retorne os 10 Pokémons com o maior número de pesquisas pelo nome.

### Observações:

- Você é livre para escolher a tecnologia e o framework que deseja usar para desenvolver a API (por exemplo, ASP.NET Core, Node.js, Django, etc.).
- Certifique-se de fornecer uma documentação clara sobre como configurar e executar o projeto, incluindo instruções para configurar o Docker Compose e iniciar o Redis e o banco de dados.
- Seja criativo e pense em soluções eficientes para atender aos requisitos do desafio.

*Boa sorte e divirta-se codificando!*