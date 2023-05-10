# Net Hangfire Logging Example

This project showcases a basic implementation of a Hangfire application. It provides an API for managing products, allowing users to create, update, and delete products, as well as sort products based on their prices. Along with Hangfire, a task is created to periodically monitor the total number of products in the database and log it. This task runs every 1 minute and provides real-time insights into the product count. The integration of Hangfire enables efficient background job scheduling and execution, ensuring seamless product management and automatic monitoring of the product count.


## Installing

1. Clone the repository
```bash
git clone https://github.com/BerkayMehmetSert/net.Hangfire.Logging.git
```

2. Install dependencies
```bash
dotnet restore
```

3. Create a database in SQL Server
```sql
CREATE DATABASE HangFireDb
```

4. Run the project
```bash
dotnet run
```

5. Open `Hangfire Dashboard` in your browser
```
http://localhost:5228/hangfire
```

## Usage

**Get all products**
```bash
GET /api/product
```

Response body:
```json
{
  "success": true,
  "message": "Products retrieved successfully",
  "data": [
    {
      "id": "4b4663fb-a819-413e-9d15-bd0b577138a1",
      "name": "Product 1",
      "description": "Description 1",
      "price": 100
    },
    {
      "id": "ef481be9-7363-4420-b62a-546d2a93420b",
      "name": "Product 2",
      "description": "Description 2",
      "price": 110
    }
  ]
}
```

**Get product by id**
```bash
GET /api/product/{id}
```

Response body:
```json
{
  "success": true,
  "message": "Product retrieved successfully",
  "data": {
    "id": "4b4663fb-a819-413e-9d15-bd0b577138a1",
    "name": "Product 1",
    "description": "Description 1",
    "price": 100
  }
}
```

**Get product by name**
```bash
GET /api/product/name/{name}
```

Response body:
```json
{
  "success": true,
  "message": "Product retrieved successfully",
  "data": {
    "id": "4b4663fb-a819-413e-9d15-bd0b577138a1",
    "name": "Product 1",
    "description": "Description 1",
    "price": 100
  }
}
```

**Get products descending by price**
```bash
GET /api/product/price/descending
```

Response body:
```json
{
  "success": true,
  "message": "Products retrieved successfully",
  "data": [
    {
      "id": "ef481be9-7363-4420-b62a-546d2a93420b",
      "name": "Product 2",
      "description": "Description 2",
      "price": 110
    }
    {
      "id": "4b4663fb-a819-413e-9d15-bd0b577138a1",
      "name": "Product 1",
      "description": "Description 1",
      "price": 100
    }
  ]
}
```

**Get products ascending by price**
```bash
GET /api/product/price/ascending
```

Response body:
```json
{
  "success": true,
  "message": "Products retrieved successfully",
  "data": [
    {
      "id": "4b4663fb-a819-413e-9d15-bd0b577138a1",
      "name": "Product 1",
      "description": "Description 1",
      "price": 100
    },
    {
      "id": "ef481be9-7363-4420-b62a-546d2a93420b",
      "name": "Product 2",
      "description": "Description 2",
      "price": 110
    }
  ]
}
```

**Create product**
```bash
POST /api/product
```

Request body:
```json
{
  "name": "Product 1",
  "description": "Description 1",
  "price": 100
}
```

Response body:
```json
{
  "success": true,
  "message": "Product created successfully"
}
```

**Update product**
```bash
PUT /api/product/{id}
```

Request body:
```json
{
  "name": "Product 1",
  "description": "Description 1",
  "price": 110
}
```

Response body:
```json
{
  "success": true,
  "message": "Product updated successfully"
}
```

**Delete product**
```bash
DELETE /api/product/{id}
```

Response body:
```json
{
  "success": true,
  "message": "Product deleted successfully"
}
```
