# CancelarNotas

Sistema para geração de arquivos de cancelamento de Notas Fiscais Eletrônicas (NFe) desenvolvido em C# Windows Forms.

## 📋 Descrição

É uma aplicação desktop que facilita o processo de criação de arquivos de cancelamento de NFe, gerando automaticamente os arquivos no formato `.txt` necessários para o cancelamento junto aos órgãos competentes. (utilizando Uninfe)

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C# 
- **Framework:** .NET Framework 4.8
- **Interface:** Windows Forms
- **IDE:** Visual Studio 2022

## 📁 Estrutura do Projeto

```
CancelarNota/
├── 📁 Classes/
│   └── NotaCancelamento.cs          # Modelo de dados para nota de cancelamento
├── 📁 Formularios/
│   ├── frmCancelarNota.cs           # Formulário principal de cancelamento
│   ├── frmPrincipal.cs              # Formulário inicial da aplicação
│   └── frmTutorial.cs               # Formulário com instruções de uso
├── 📁 Properties/
│   ├── AssemblyInfo.cs              # Informações do assembly
│   ├── Resources.Designer.cs        # Recursos da aplicação
│   ├── Resources.resx               # Arquivo de recursos
│   ├── Settings.Designer.cs         # Configurações da aplicação
│   └── Settings.settings            # Arquivo de configurações
├── 📁 Repositorios/
│   └── NotaCancelamentoRepositorio.cs # Lógica de persistência e validação
├── App.config                       # Configurações da aplicação
├── Program.cs                       # Ponto de entrada da aplicação
├── CancelarNotas.csproj          # Arquivo de projeto
├── CancelarNotas.sln             # Arquivo de solução
├── nota.ico                      # Ícone da aplicação
└── LICENSE.txt                     # Licença MIT
```

## 🔧 Detalhamento das Classes

### 📋 Classes/NotaCancelamento.cs
**Modelo de dados** que representa uma nota de cancelamento com as seguintes propriedades:
- `Arquivo` - Nome do arquivo
- `IdLote` - Identificador do lote
- `Evento` - Tipo de evento
- `Id` - Identificador único
- `COrgao` - Código do órgão
- `TpAmb` - Tipo de ambiente (produção/homologação)
- `Cnpj` - CNPJ da empresa
- `ChNFe` - Chave da NFe a ser cancelada
- `DhEvento` - Data/hora do evento
- `TpEvento` - Tipo do evento de cancelamento
- `NSeqEvento` - Número sequencial do evento
- `VerEvento` - Versão do evento
- `DescEvento` - Descrição do evento
- `NProt` - Número do protocolo
- `XJust` - Justificativa do cancelamento

### 🗄️ Repositorios/NotaCancelamentoRepositorio.cs
**Camada de persistência** responsável por:
- **Validação de dados**: Verifica se todos os campos obrigatórios estão preenchidos
- **Geração de arquivo**: Cria arquivo `.txt` no formato específico para cancelamento
- **Tratamento de erros**: Captura e retorna mensagens de erro
- **Criação de diretórios**: Garante que o caminho de destino existe

**Principais métodos:**
- `SalvarComoTxt()` - Salva os dados da nota como arquivo de texto
- `ValidarDados()` - Valida se todos os campos obrigatórios estão preenchidos

### 🖥️ Formularios/
- **frmPrincipal.cs**: Formulário inicial da aplicação, ponto de partida para o usuário
- **frmCancelarNota.cs**: Formulário principal onde o usuário insere os dados para cancelamento
- **frmTutorial.cs**: Formulário com instruções e tutorial de uso do sistema

### 🚀 Program.cs
**Ponto de entrada** da aplicação que:
- Inicializa a aplicação Windows Forms
- Define o formulário principal como `frmPrincipal`
- Configura estilos visuais

## 📦 Instalação e Uso

### Pré-requisitos
- Windows 7 ou superior
- .NET Framework 4.8 instalado

### Como usar
1. Execute o arquivo `CancelarNota.exe`
2. Preencha todos os campos obrigatórios no formulário de cancelamento
3. Defina o diretório de destino para salvar o arquivo
4. Clique em "Salvar" para criar o arquivo de cancelamento
5. O arquivo será salvo com o nome `Cancel{ChaveNFe}-ped-eve.txt`

## 📄 Formato do Arquivo de Saída

O sistema gera um arquivo `.txt` com o seguinte formato:
```
idLote|{valor}
evento|{valor}
id|{valor}
cOrgao|{valor}
tpAmb|{valor}
CNPJ|{valor}
chNFe|{valor}
dhEvento|{valor}
tpEvento|{valor}
nSeqEvento|{valor}
verEvento|{valor}
descEvento|{valor}
nProt|{valor}
xJust|{valor}
```

## ⚠️ Validações

O sistema realiza as seguintes validações:
- ✅ Todos os campos são obrigatórios
- ✅ Verificação de formato dos dados
- ✅ Criação automática de diretórios
- ✅ Tratamento de exceções durante salvamento

## 📝 Licença

Este projeto está licenciado sob a **Licença MIT** - veja o arquivo [LICENSE.txt](LICENSE.txt) para mais detalhes.

## 🏢 Sobre

Desenvolvido para facilitar o processo de cancelamento de Notas Fiscais Eletrônicas, automatizando a geração dos arquivos necessários para submissão aos órgãos competentes.

---

**Nota:** Este sistema gera apenas os arquivos de cancelamento. O envio aos órgãos fiscais deve ser realizado através dos sistemas oficiais competentes.
