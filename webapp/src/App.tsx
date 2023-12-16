import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { LoginPage } from './pages/LoginPage'
import { AppPage } from './pages/AppPage'

function App() {


  return (
    <BrowserRouter>
      <Routes>
        <Route path='/login' element={<LoginPage />} />
        <Route path='/app' element={<AppPage />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
