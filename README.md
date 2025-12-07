# Algoritmos Grafos API

Uma API RESTful em .NET 8 para análise de algoritmos de grafos. Implementa algoritmos clássicos como BFS, DFS, Dijkstra e Prim.

## 🚀 Requisitos

- **.NET 8.0 SDK** ou superior ([Download](https://dotnet.microsoft.com/download/dotnet/8.0))
- **Git** (opcional, para clonar o repositório)

## 📦 Instalação

### 1. Clonar o repositório

```bash
git clone https://github.com/samuelfigueired/Algoritmos-Grafos-api.git
cd Algoritmos-Grafos-api
```

### 2. Restaurar dependências

```bash
dotnet restore
```

## ▶️ Como Rodar a Aplicação

### Opção 1: Linha de comando

```bash
cd GraphAnalyzer.Api
dotnet run
```

### Opção 2: Visual Studio Code

1. Abra a pasta do projeto no VS Code
2. Pressione `F5` ou vá em **Run** > **Start Debugging**

### Opção 3: Visual Studio

1. Abra o arquivo `GraphAnalyzer.Api.sln`
2. Pressione `F5` para executar

## 🌐 Acessar a API

Após iniciar a aplicação, a API estará disponível em:

- **URL Base**: `http://localhost:5070`
- **Swagger/OpenAPI**: `http://localhost:5070/swagger/index.html`

## 📚 Endpoints Disponíveis

### 1. BFS (Busca em Largura)

```
POST /api/graph/bfs
Content-Type: application/json

{
  "adjacencyMatrix": [[0, 1, 1], [1, 0, 0], [1, 0, 0]],
  "vertices": 3
}
```

**Parâmetros Query:**
- `start` (padrão: 0) - Vértice inicial

### 2. DFS (Busca em Profundidade)

```
POST /api/graph/dfs
Content-Type: application/json

{
  "adjacencyMatrix": [[0, 1, 1], [1, 0, 0], [1, 0, 0]],
  "vertices": 3
}
```

**Parâmetros Query:**
- `start` (padrão: 0) - Vértice inicial

### 3. Dijkstra (Caminho Mínimo)

```
POST /api/graph/dijkstra
Content-Type: application/json

{
  "adjacencyMatrix": [[0, 4, 2], [4, 0, 1], [2, 1, 0]],
  "vertices": 3
}
```

**Parâmetros Query:**
- `start` (obrigatório) - Vértice inicial

### 4. Prim (Árvore Geradora Mínima)

```
POST /api/graph/prim
Content-Type: application/json

{
  "adjacencyMatrix": [[0, 4, 2], [4, 0, 1], [2, 1, 0]],
  "vertices": 3
}
```

## 🏗️ Estrutura do Projeto

```
GraphAnalyzer.Api/
├── Controllers/
│   ├── GraphController.cs      # Endpoints da API
│   └── WeatherForecastController.cs
├── Models/
│   └── Graph.cs               # Modelo de dados do grafo
├── Services/
│   └── GraphService.cs        # Lógica dos algoritmos
├── Program.cs                 # Configuração da aplicação
├── appsettings.json           # Configurações
└── GraphAnalyzer.Api.csproj   # Arquivo de projeto
```

## 🔧 Configuração CORS

A API está configurada para aceitar requisições do frontend em `http://localhost:3000`.

Para alterar a origem permitida, edite o arquivo `Program.cs`:

```csharp
builder.WithOrigins("http://localhost:3000") // Altere aqui
    .AllowAnyMethod()
    .AllowAnyHeader();
```

## 📝 Exemplo de Uso com cURL

```bash
# BFS
curl -X POST http://localhost:5070/api/graph/bfs \
  -H "Content-Type: application/json" \
  -d '{"adjacencyMatrix": [[0,1,1],[1,0,0],[1,0,0]], "vertices": 3}' \
  -G -d "start=0"

# DFS
curl -X POST http://localhost:5070/api/graph/dfs \
  -H "Content-Type: application/json" \
  -d '{"adjacencyMatrix": [[0,1,1],[1,0,0],[1,0,0]], "vertices": 3}' \
  -G -d "start=0"

# Dijkstra
curl -X POST http://localhost:5070/api/graph/dijkstra \
  -H "Content-Type: application/json" \
  -d '{"adjacencyMatrix": [[0,4,2],[4,0,1],[2,1,0]], "vertices": 3}' \
  -G -d "start=0"

# Prim
curl -X POST http://localhost:5070/api/graph/prim \
  -H "Content-Type: application/json" \
  -d '{"adjacencyMatrix": [[0,4,2],[4,0,1],[2,1,0]], "vertices": 3}'
```

## 🛑 Parar a Aplicação

Pressione `Ctrl+C` no terminal para encerrar a API.

## 📖 Documentação Adicional

- [.NET 8 Documentation](https://docs.microsoft.com/dotnet/)
- [ASP.NET Core](https://docs.microsoft.com/aspnet/core/)


## 📄 Licença

Este projeto está sob licença MIT.
