# Desafio de Desenvolvimento de API de Pokémons

Bem-vindo ao Desafio de Desenvolvimento de API de Pokémons! Este desafio tem como objetivo criar uma API RESTful que forneça informações sobre Pokémons e atenda aos seguintes requisitos:

## Requisitos Funcionais:

1. **Endpoint para Buscar um Pokémon pelo Nome:**
   - Crie um endpoint `/api/pokemon/{nome}` que permita aos usuários buscar um Pokémon pelo seu nome.
   - Acesse a PokeAPI [https://pokeapi.co/] para consultar o Pokémon pelo nome e receba o seguinte JSON: 
     ```json
      {"name":"Pikachu","height":3,"weight":120,"types":[{"type":{"name":"psychic"}}],"sprites":{"other":{"dream_world":{"front_default":"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/150.svg"}}}}
     ```

2. **Endpoint para Retornar os 10 Pokémons Mais Famosos:**
   - Implemente um endpoint `/api/pokemon/famous` que retorne os X Pokémons mais famosos com base no número de vezes que foram pesquisados pelo nome.

## Requisitos Não Funcionais:

1. **Cobertura de Testes Unitários:**
   - Garanta que sua aplicação tenha uma cobertura de testes unitários de pelo menos 80%.

2. **Utilização do Redis:**
   - Utilize o Redis para armazenar informações sobre os Pokémons pesquisados e o número de vezes que foram buscados.

3. **Utilização de Docker Compose para o Banco de Dados:**
   - Utilize o Docker Compose para configurar e executar o banco de dados usado pela aplicação.

## Regras de Negócio Adicionais:

1. **Registro de Buscas de Pokémon:**
   - Cada vez que um Pokémon é buscado pelo nome, registre essa busca no banco de dados, incrementando o contador de vezes que ele foi pesquisado.

2. **Cálculo dos Pokémons Mais Famosos:**
   - Para determinar os Pokémons mais famosos, consulte o banco de dados e retorne os X Pokémons com o maior número de pesquisas pelo nome.

## Detalhes da Implementação:

### Instalação:

1. Clone o repositório do projeto:
   
   ```bash
   git clone https://github.com/rodriguesnivea/FamousPokemon.git
   ```

2. Navegue até o diretório do projeto e execute o Docker Compose para configurar o banco de dados e o Redis:
   
   ```bash
   docker-compose up -d
   ```

3. Abra o projeto em sua IDE de preferência (por exemplo, Visual Studio) e execute a aplicação.

### Uso:

- Para buscar um Pokémon pelo nome, faça uma requisição GET para o endpoint `/api/pokemon/{nome}`.
  - Exemplo de Requisição:
    
    ```bash
    GET /api/pokemon/pikachu
    ```
  
  - Exemplo de Resposta:
    ```json
    {
        "id": 25,
        "nome": "Pikachu",
        "tipo": ["Elétrico"],
        "altura": 0.4,
        "peso": 6.0
    }
    ```

- Para obter os 10 Pokémon mais famosos, faça uma requisição GET para o endpoint `/api/pokemon/famous`.
  - Exemplo de Requisição:
    
    ```bash
    GET /api/pokemon/famous
    ```
  
  - Exemplo de Resposta:
    ```json
    [
        {"id": 25, "nome": "Pikachu", "tipo": ["Elétrico"], "altura": 0.4, "peso": 6.0},
        {"id": 6, "nome": "Charizard", "tipo": ["Fogo", "Voador"], "altura": 1.7, "peso": 90.5},
        // Outros Pokémon famosos aqui...
    ]
    ```

### Observações:

- Certifique-se de fornecer uma documentação clara sobre como configurar e executar o projeto, incluindo instruções para configurar o Docker Compose e iniciar o Redis e o banco de dados.
- Seja criativo e pense em soluções eficientes para atender aos requisitos do desafio.

*Boa sorte e divirta-se codificando!*  
