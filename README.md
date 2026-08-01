# CancelarNotas

[English](#en) | [Português](#pt-BR)

---

<a name="pt-BR"></a>
## 🇧🇷 Português

## 📋 Descrição

Sistema para geração de arquivos de cancelamento de **Notas Fiscais Eletrônicas (NFe)** desenvolvido em **C# Windows Forms**.

É uma aplicação desktop que facilita o processo de criação de arquivos de cancelamento de NFe, gerando automaticamente os arquivos no formato `.txt` necessários para o cancelamento por meio do **UniNFe**.

## 🛠️ Tecnologias Utilizadas

* **Linguagem:** C#
* **Framework:** .NET Framework 4.8
* **Interface:** Windows Forms
* **IDE:** Visual Studio 2022

## 📁 Estrutura do Projeto

```text
CancelarNotas/
├── 📁 Classes/
│   └── NotaCancelamento.cs
├── 📁 Formularios/
│   ├── frmCancelarNota.cs
│   ├── frmPrincipal.cs
│   └── frmTutorial.cs
├── 📁 Properties/
│   ├── AssemblyInfo.cs
│   ├── Resources.Designer.cs
│   ├── Resources.resx
│   ├── Settings.Designer.cs
│   └── Settings.settings
├── 📁 Repositorios/
│   └── NotaCancelamentoRepositorio.cs
├── App.config
├── Program.cs
├── CancelarNotas.csproj
├── CancelarNotas.sln
├── nota.ico
└── LICENSE.txt
```

## 🔧 Componentes

### 📋 `Classes/NotaCancelamento.cs`

Modelo de dados responsável por representar uma solicitação de cancelamento de NFe.

Principais propriedades:

* Arquivo
* IdLote
* Evento
* Id
* COrgao
* TpAmb
* Cnpj
* ChNFe
* DhEvento
* TpEvento
* NSeqEvento
* VerEvento
* DescEvento
* NProt
* XJust

### 🗄️ `Repositorios/NotaCancelamentoRepositorio.cs`

Responsável por:

* Validação dos dados obrigatórios
* Geração do arquivo `.txt`
* Tratamento de exceções
* Criação automática do diretório de destino

Principais métodos:

* `SalvarComoTxt()`
* `ValidarDados()`

### 🖥️ Formulários

* **frmPrincipal.cs** — Tela inicial da aplicação.
* **frmCancelarNota.cs** — Tela principal para preenchimento dos dados do cancelamento.
* **frmTutorial.cs** — Tutorial de utilização do sistema.

### 🚀 `Program.cs`

Ponto de entrada da aplicação responsável por:

* Inicializar o Windows Forms
* Definir `frmPrincipal` como formulário inicial
* Configurar os estilos visuais

---

## 📦 Instalação

### Pré-requisitos

* Windows 7 ou superior
* .NET Framework 4.8

### Como utilizar

1. Execute `CancelarNotas.exe`;
2. Preencha todos os campos obrigatórios;
3. Escolha o diretório de destino;
4. Clique em **Salvar**;
5. Será gerado o arquivo:

```text
Cancel{ChaveNFe}-ped-eve.txt
```

---

## 📄 Formato do Arquivo

```text
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

---

## ✅ Validações

* Todos os campos são obrigatórios
* Validação dos dados informados
* Criação automática do diretório
* Tratamento de erros durante o salvamento

---

## 📝 Licença

Este projeto está licenciado sob a **Licença MIT**.

Consulte o arquivo **LICENSE.txt** para mais informações.

---

## 🏢 Sobre

O CancelarNotas automatiza a geração dos arquivos de cancelamento de NF-e utilizados pelo **UniNFe**, simplificando o processo de criação dos arquivos necessários para envio aos órgãos fiscais.

> **Observação:** Esta aplicação gera apenas o arquivo de cancelamento. O envio da solicitação deve ser realizado através do UniNFe ou outro software autorizado.

---

<a name="en"></a>
## 🇺🇸 English

## 📋 Description

**CancelarNotas** is a desktop application built with **C# Windows Forms** that generates cancellation request files for Brazilian **Electronic Invoices (NF-e)**.

The application automatically creates the `.txt` files required by **UniNFe** to process NF-e cancellation requests.

## 🛠️ Technologies

* **Language:** C#
* **Framework:** .NET Framework 4.8
* **UI:** Windows Forms
* **IDE:** Visual Studio 2022

## 📁 Project Structure

```text
CancelarNotas/
├── 📁 Classes/
│   └── NotaCancelamento.cs
├── 📁 Formularios/
│   ├── frmCancelarNota.cs
│   ├── frmPrincipal.cs
│   └── frmTutorial.cs
├── 📁 Properties/
│   ├── AssemblyInfo.cs
│   ├── Resources.Designer.cs
│   ├── Resources.resx
│   ├── Settings.Designer.cs
│   └── Settings.settings
├── 📁 Repositorios/
│   └── NotaCancelamentoRepositorio.cs
├── App.config
├── Program.cs
├── CancelarNotas.csproj
├── CancelarNotas.sln
├── nota.ico
└── LICENSE.txt
```

## 🔧 Components

### 📋 `Classes/NotaCancelamento.cs`

Data model representing an NF-e cancellation request.

Main properties:

* FileName
* BatchId
* Event
* Id
* OrganizationCode
* EnvironmentType
* CompanyTaxId (CNPJ)
* InvoiceKey (NF-e Key)
* EventDateTime
* EventType
* EventSequence
* EventVersion
* EventDescription
* ProtocolNumber
* CancellationReason

### 🗄️ `Repositorios/NotaCancelamentoRepositorio.cs`

Responsible for:

* Required field validation
* `.txt` file generation
* Exception handling
* Automatic destination folder creation

Main methods:

* `SalvarComoTxt()`
* `ValidarDados()`

### 🖥️ Forms

* **frmPrincipal.cs** — Application startup screen.
* **frmCancelarNota.cs** — Main form used to fill cancellation information.
* **frmTutorial.cs** — User guide and tutorial.

### 🚀 `Program.cs`

Application entry point responsible for:

* Initializing Windows Forms
* Loading `frmPrincipal`
* Configuring visual styles

---

## 📦 Installation

### Requirements

* Windows 7 or later
* .NET Framework 4.8

### Usage

1. Run `CancelarNotas.exe`;
2. Fill in all required fields;
3. Select the destination folder;
4. Click **Save**;
5. The application will generate:

```text
Cancel{InvoiceKey}-ped-eve.txt
```

---

## 📄 Output File Format

```text
idLote|{value}
evento|{value}
id|{value}
cOrgao|{value}
tpAmb|{value}
CNPJ|{value}
chNFe|{value}
dhEvento|{value}
tpEvento|{value}
nSeqEvento|{value}
verEvento|{value}
descEvento|{value}
nProt|{value}
xJust|{value}
```

---

## ✅ Validation

The application performs the following validations:

* Required field validation
* Input data verification
* Automatic directory creation
* Exception handling during file generation

---

## 📝 License

This project is licensed under the **MIT License**.

See **LICENSE.txt** for more information.

---

## 🏢 About

CancelarNotas simplifies the generation of NF-e cancellation request files used by **UniNFe**, automating the creation of the files required for submission to the Brazilian tax authorities.

> **Note:** This application only generates the cancellation request file. The submission must be performed through UniNFe or another authorized NF-e software.
