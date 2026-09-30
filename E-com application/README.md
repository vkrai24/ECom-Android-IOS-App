# E-Commerce Mobile Application

A complete Android e-commerce application built with React Native frontend and .NET Core backend API with SQL Server database.

## 🚀 Features

### Mobile App (React Native)
- ✅ User Authentication (Login/Register)
- ✅ Product Catalog with Categories
- ✅ Product Search & Filtering
- ✅ Product Details with Images
- ✅ Shopping Cart Management
- ✅ Checkout Process
- ✅ Multiple Payment Methods
- ✅ Order History
- ✅ User Profile Management
- ✅ Beautiful Modern UI with Gradients

### Backend API (.NET Core)
- ✅ RESTful API Architecture
- ✅ JWT Authentication & Authorization
- ✅ Entity Framework Core with SQL Server
- ✅ User Management
- ✅ Product Management
- ✅ Order Processing
- ✅ Payment Processing
- ✅ Swagger API Documentation

## 📁 Project Structure

```
E-com application/
├── ECommerceApp/           # React Native Mobile App
│   ├── src/
│   │   ├── screens/        # All app screens
│   │   ├── components/     # Reusable components
│   │   ├── navigation/     # React Navigation setup
│   │   ├── redux/          # Redux state management
│   │   ├── services/       # API services
│   │   └── utils/          # Utility functions
│   ├── android/            # Android native code
│   ├── ios/                # iOS native code
│   └── package.json
│
└── ECommerceAPI/           # .NET Core Web API
    ├── Controllers/        # API Controllers
    ├── Models/             # Database Models
    ├── Services/           # Business Logic
    ├── Data/               # DbContext & Migrations
    ├── DTOs/               # Data Transfer Objects
    └── Program.cs
```

## 🛠️ Technology Stack

### Frontend
- React Native 0.83
- Redux Toolkit for state management
- React Navigation for routing
- Axios for HTTP requests
- React Native Linear Gradient
- AsyncStorage for local persistence

### Backend
- .NET Core 8.0
- Entity Framework Core
- SQL Server / LocalDB
- JWT Authentication
- Swagger/OpenAPI
- BCrypt for password hashing

## 📋 Prerequisites

### For React Native App
- Node.js (v18 or higher)
- npm or yarn
- Android Studio (for Android development)
- Xcode (for iOS development - macOS only)
- React Native CLI

### For Backend API
- .NET 8.0 SDK
- SQL Server or SQL Server Express
- Visual Studio 2022 or VS Code

## 🔧 Installation & Setup

### 1. Backend API Setup

```bash
cd ECommerceAPI

# Restore NuGet packages (if .NET is installed)
dotnet restore

# Update database connection string in appsettings.json
# Default: Server=(localdb)\\mssqllocaldb;Database=ECommerceDB;Trusted_Connection=True

# Run the API
dotnet run
```

The API will start at `http://localhost:5000`
Swagger UI: `http://localhost:5000/swagger`

### 2. React Native App Setup

```bash
cd ECommerceApp

# Install dependencies (already done)
npm install

# Install iOS pods (macOS only)
cd ios && pod install && cd ..

# Update API URL in src/services/api.ts
# For Android Emulator: http://10.0.2.2:5000/api
# For iOS Simulator: http://localhost:5000/api
# For Physical Device: http://YOUR_COMPUTER_IP:5000/api
```

### 3. Run the Mobile App

#### Android
```bash
# Start Metro bundler
npm start

# In another terminal, run Android app
npm run android
# or
npx react-native run-android
```

#### iOS (macOS only)
```bash
# Start Metro bundler
npm start

# In another terminal, run iOS app
npm run ios
# or
npx react-native run-ios
```

## 📱 App Screens

1. **Login Screen** - User authentication with email & password
2. **Register Screen** - New user registration
3. **Home Screen** - Product catalog with categories & search
4. **Product Detail Screen** - Detailed product view with add to cart
5. **Cart Screen** - Shopping cart management
6. **Checkout Screen** - Shipping information
7. **Payment Screen** - Payment method selection & card details
8. **Orders Screen** - Order history
9. **Profile Screen** - User profile & settings

## 🔐 Authentication

### Test User (if you seed the database)
```
Email: test@example.com
Password: Test123!
```

### Register New User
Use the registration screen in the app or call the API:
```
POST http://localhost:5000/api/auth/register
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@example.com",
  "password": "Password123",
  "phone": "+1234567890"
}
```

## 🗄️ Database

The application uses SQL Server with Entity Framework Core. The database is automatically created with seed data when you first run the API.

### Tables
- Users - User accounts
- Products - Product catalog (pre-seeded with 8 products)
- Orders - Customer orders
- OrderItems - Order line items
- Payments - Payment transactions

## 🌐 API Endpoints

### Authentication
- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - Login user

### Products
- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `GET /api/products/category/{category}` - Get products by category
- `GET /api/products/search?q={query}` - Search products

### Orders (Requires Authentication)
- `GET /api/orders` - Get user orders
- `POST /api/orders` - Create new order

## 🎨 UI Features

- Modern gradient backgrounds
- Smooth animations
- Intuitive navigation
- Responsive design
- Loading states
- Error handling
- Empty states
- Pull to refresh
- Form validation

## 📦 State Management

Redux Toolkit is used for state management with the following slices:
- **authSlice** - User authentication state
- **productSlice** - Product catalog
- **cartSlice** - Shopping cart with persistence

## 🔒 Security Features

- JWT token-based authentication
- Password hashing with BCrypt
- Secure token storage with AsyncStorage
- Protected API routes
- Input validation
- SQL injection prevention (EF Core)

## 🚧 Development Notes

### Android Emulator Network
- Use `http://10.0.2.2:5000` to access localhost from Android emulator

### iOS Simulator Network
- Use `http://localhost:5000` for iOS simulator

### Physical Device
- Ensure your device and computer are on the same network
- Use your computer's IP address: `http://192.168.x.x:5000`

## 📝 Mock Data

The app includes mock product data that works even without the backend running. This allows you to test the UI independently.

## 🐛 Troubleshooting

### React Native Issues
```bash
# Clear cache
npm start -- --reset-cache

# Clean Android build
cd android && ./gradlew clean && cd ..

# Rebuild
npm run android
```

### Backend Issues
- Ensure SQL Server is running
- Check connection string in appsettings.json
- Verify .NET 8.0 SDK is installed

## 📄 License

This project is for educational purposes.

## 👥 Author

Built as a complete e-commerce solution demonstrating modern mobile and web development practices.

## 🙏 Acknowledgments

- React Native Community
- .NET Foundation
- Microsoft Entity Framework
- Redux Toolkit Team
