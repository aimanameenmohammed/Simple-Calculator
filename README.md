<div align="center">

# 🧮 Smart & Clean WinForms Calculator

[![C#](https://img.shields.io/badge/Language-C%23-blue.svg?style=for-the-badge&logo=c-sharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Framework](https://img.shields.io/badge/Framework-.NET%20Framework-purple.svg?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![UI/UX](https://img.shields.io/badge/UI%2FUX-Mobile--Style%20WinForms-orange.svg?style=for-the-badge)](https://github.com/)
[![Code Style](https://img.shields.io/badge/Architecture-Clean%20%26%20Maintainable-green.svg?style=for-the-badge)](https://github.com/)

<p align="center">
  <b>A sleek, mobile-inspired calculator built with C# WinForms, demonstrating clean architecture and unified control management.</b>
</p>

[📌 Overview](#-overview) •
[✨ Key Features](#-key-features) •
[📸 Screenshot](#-screenshot) •
[💡 Technical Highlights](#-technical-highlights) •
[🚀 Getting Started](#-getting-started) •
[📞 Connect With Me](#-connect-with-me)

---

</div>

## 📌 Overview

The **Smart & Clean WinForms Calculator** is a desktop application designed to provide a smooth, mobile-like user experience for daily arithmetic operations. Beyond standard calculation functionalities, this project focuses on demonstrative software engineering practices—showing how clean code, smart casting, and unified event handling can make even simple projects highly maintainable and elegant.

---

## ✨ Key Features

* 📱 **Mobile-Inspired UI:** Sleek, modern, and intuitive interface design focused on usability.
* ⚡ **Unified Control Reference:** Uses a single dynamic control reference to manage active button states, colors, and property updates centrally.
* 🎯 **Dynamic Event Handling:** Minimizes repetitive code by routing button events through streamlined handlers.
* 🧼 **Clean & Maintainable Architecture:** Built adhering to the DRY (Don't Repeat Yourself) principle for maximum code readability.
* 🧮 **Core Arithmetic Logic:** Supports standard operations with smooth state transitions.

---

## 📸 Screenshot

<div align="center">

| Application Interface |
| :---: |
| <img src="Calculator%20Picture.png" alt="Calculator Project UI" width="450"> |

</div>

---

## 💡 Technical Highlights

### Unified Control Architecture
Instead of attaching individual properties and style handlers across multiple buttons, the project leverages dynamic reference casting to manage sender controls from a central point:

```csharp
// Dynamic sender casting for unified property management
this.sender = (Control)sender;

```
---
## 📥 Installation & How to Run

### ⚙️ Prerequisites
* **Visual Studio 2019** or newer.
* **.NET Framework 4.8** or higher.


### 🚀 Getting Started

#### Option 1: Clone via Git (Recommended)
1. Open your terminal or Command Prompt and run:
   ```bash
   git clone [https://github.com/aimanameenmohammed/Simple-Calculator.git]
