import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { LoginPage } from './features/auth/pages/LoginPage'
import { AppPage } from './global/AppPage'
import { UsuarioPage } from './features/usuario/pages/UsuarioPage'
import { SolicitudPage } from './features/solicitud/pages/SolicitudPage'
import { TipoSolicitudPage } from './features/solicitud/pages/TipoSolicitud'
import { UsuarioZonaPage } from './features/usuario/pages/UsuarioZonaPage'
import { UsuarioTipoSolicitudPage } from './features/usuario/pages/UsuarioTipoSolicitudPage'
import { HomePage } from './global/HomePage'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/login' element={<LoginPage />} />
        <Route path='/' element={<AppPage />} >
          <Route index element={<HomePage />} />
          <Route path="usuarios" element={<UsuarioPage />} />
          <Route path="solicitudes" element={<SolicitudPage />} />
          <Route path="tipos-solicitudes" element={<TipoSolicitudPage />} />
          <Route path="usuario-zona" element={<UsuarioZonaPage />} />
          <Route path="usuario-tiposolicitud" element={<UsuarioTipoSolicitudPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  )
}

export default App
