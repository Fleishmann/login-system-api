# login-system-api

## Instruções de Configuração

### Banco de Dados SQL Server
Antes de usar a API, crie um banco de dados SQL Server com o nome que preferir. Você pode fazer isso executando o seguinte comando:

```sql
CREATE DATABASE NomeDoBancoDeDados;
```

### Configuração da Conexão com o Banco de Dados
Faça as alterações necessárias na string de conexão no arquivo `appsettings.json` para refletir as informações do seu banco de dados:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server='SEU_SERVIDOR'; Database='SEU_BANCO_DE_DADOS';User Id='SEU_USUARIO';Password='SUA_SENHA'; TrustServerCertificate='true'"
}
```

### Aplicação das Migrações
Após configurar a string de conexão, execute o seguinte comando no terminal para aplicar as migrações e criar as tabelas no banco de dados:

```bash
dotnet ef database update
```

Com isso, o código estará funcional e pronto para uso.
