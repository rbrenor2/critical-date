# Critical Date

Critical Date is a price markdown management system designed for supermarket chains to manage price reduction requests for products approaching their expiration date.

The system helps stores reduce product waste while ensuring that price reductions follow the company's financial and operational policies.

## The Problem

Supermarket branches frequently have inventory approaching its expiration date.

Rather than allowing these products to expire and become a complete loss, store managers can request temporary price reductions to increase the likelihood of selling the remaining inventory.

However, approving every markdown automatically can create other problems:

- Stores operate within defined markdown budgets.
- Large discounts may require additional approval.
- High-value requests can have a significant financial impact.
- Different situations may require different approval rules.
- Price changes need to be traceable and auditable.

Critical Date provides a centralized workflow for handling these requests.

## How It Works

When inventory approaches its expiration date, a store manager creates a price change request specifying the desired new price.

The system evaluates the request against business rules such as:

- Remaining store markdown budget
- Product expiration date
- Discount percentage
- Quantity of affected inventory
- Total financial impact of the markdown

Based on these rules, the request can be automatically approved or sent to an analyst for manual review.

```text
Product approaching expiration
            │
            ▼
 Store Manager requests
     a price reduction
            │
            ▼
   ┌─────────────────┐
   │ Business Rules  │
   │   Evaluation    │
   └────────┬────────┘
            │
       ┌────┴────┐
       │         │
       ▼         ▼
 Auto-approved   Manual Review
       │              │
       │              ▼
       │           Analyst
       │         ┌────┴────┐
       │         │         │
       │      Approve    Reject
       │         │         │
       └─────────┴────┬────┘
                      │
                      ▼
              Request completed
                      │
                      ▼
              Manager notified
```

## Example

A store has 20 units of a product approaching its expiration date.

```text
Current price:        €4.99
Requested price:      €1.49
Quantity:                20

Markdown impact:

(€4.99 - €1.49) × 20 = €70
```

The system evaluates the €70 markdown against the store's available budget and the configured approval rules.

A request within the permitted thresholds can be approved automatically.

A request involving an unusually large discount or financial impact can instead be routed to an analyst.

## Core Domain

### Product

Represents a product sold by the supermarket chain.

### Store

Represents an individual supermarket branch and its available markdown budget.

### Inventory Item

Associates a product with inventory held by a particular store, including:

- Current price
- Quantity
- Expiration date

### Price Change Request

Represents a manager's request to reduce the price of inventory.

A request maintains information such as:

- Original price
- Requested price
- Quantity
- Financial impact
- Request status
- Requesting manager
- Creation date
- Review information

### User

Represents users interacting with the workflow.

The system supports different responsibilities, including:

- Store Managers
- Analysts
- Administrators

## Request Lifecycle

A price change request progresses through a controlled lifecycle.

```text
Created
   │
   ▼
Evaluating
   │
   ├──────────────► Approved
   │
   ├──────────────► Pending Review
   │                    │
   │               ┌────┴────┐
   │               ▼         ▼
   │            Approved   Rejected
   │
   └──────────────► Rejected
```

This makes each pricing decision traceable from the original request through its final outcome.

## Business Rules

Approval rules are kept separate from the API layer so that pricing policies can evolve independently of HTTP endpoints or persistence concerns.

Examples include:

```text
StoreBudgetRule
ExpirationDateRule
MaximumDiscountRule
MaximumAutomaticApprovalValueRule
```

This allows new pricing policies to be introduced without redesigning the request workflow.

## Architecture

The application separates HTTP concerns, business workflows, domain rules and infrastructure.

```text
                    Client
                       │
                       ▼
                ASP.NET Core API
                       │
                       ▼
                  Application
                       │
                       ▼
                     Domain
                       │
                       ▼
                Infrastructure
                       │
                       ▼
                  PostgreSQL
```

The project is organized around the following responsibilities:

```text
CriticalDate.Api
├── HTTP endpoints
├── Authentication
└── Authorization

CriticalDate.Application
├── Application workflows
└── Use cases

CriticalDate.Domain
├── Entities
├── Business rules
└── Domain events

CriticalDate.Infrastructure
├── Entity Framework Core
├── PostgreSQL
└── External integrations
```

## Technology Stack

- **C#**
- **.NET**
- **ASP.NET Core**
- **Entity Framework Core**
- **PostgreSQL**
- **xUnit**
- **Docker**
- **GitHub Actions**
- **Kubernetes**

## Deployment

The application is designed to run as a stateless containerized service.

```text
GitHub
   │
   ▼
GitHub Actions
   │
   ├── Build
   ├── Test
   └── Build Container
           │
           ▼
    Container Registry
           │
           ▼
       Kubernetes
           │
           ▼
    Critical Date API
           │
           ▼
       PostgreSQL
```

This allows multiple API instances to run behind a Kubernetes service while sharing managed external infrastructure such as PostgreSQL.

## Goals

Critical Date aims to provide a clear and auditable process for supermarket markdown decisions while balancing three competing objectives:

**Reduce waste** by helping stores sell inventory before expiration.

**Protect margins** by enforcing financial limits and approval policies.

**Reduce operational overhead** by automatically approving straightforward requests while escalating exceptional cases to analysts.
