import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { LoginPage } from './features/auth/pages/LoginPage'
import { AppPage } from './global/AppPage'
import { UsuarioPage } from './features/usuario/pages/UsuarioPage'

function App() {


  return (
    <BrowserRouter>
      <Routes>
        <Route path='/login' element={<LoginPage />} />
        <Route path='/app' element={<AppPage />} >
          <Route path="usuarios" element={<UsuarioPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  )
}

export default App
