import { useState } from "react";
import { useFetchUsuario } from "../hooks/useFetchUsuario";
import { IZona } from "../interface/IZona";
import axios from "axios";
import { APIURL } from "../../../constants";
import { UsuarioZonaTable } from "../components/UsuarioZonaTable";


export const UsuarioZonaPage = () => {
    const { usuarios } = useFetchUsuario();
    const [usuarioId, setUsuarioId] = useState<number>();
    const [zonasAsignadas, setZonasAsignadas] = useState<IZona[]>([]);
    const [zonasNoAsignadas, setZonasNoAsignadas] = useState<IZona[]>([]);

    const obtenerZonasAsignadasUsuario = async (usuarioId: number) => {
        try {
            const request = await axios.get<IZona[]>(`${APIURL}/api/usuario/zona/asignadas/${usuarioId}`, { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } });
            setZonasAsignadas(request.data);
        } catch (err) {

        }
    }

    const obtenerZonasNoAsignadasUsuario = async (usuarioId: number) => {
        try {
            const request = await axios.get<IZona[]>(`${APIURL}/api/usuario/zona/noasignadas/${usuarioId}`, { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } });
            setZonasNoAsignadas(request.data);
        } catch (err) {

        }
    }

    const handleUsuarioSeleccionado = async (id: number) => {
        try {
            setUsuarioId(id);
            await obtenerZonasAsignadasUsuario(id);
            await obtenerZonasNoAsignadasUsuario(id);
        } catch (err) {

        }
    }

    const asignarZonaUsuario = async (zonaId: number) => {
        try {
            if (usuarioId === undefined) {
                alert("favor seleccionar un usuario");
                return;
            }

            await axios.post(`${APIURL}/api/usuario/zona/asignar`, { usuarioId, zonaId }, { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } });
            await obtenerZonasAsignadasUsuario(usuarioId);
            await obtenerZonasNoAsignadasUsuario(usuarioId);
        } catch (err) {

        }
    }

    const removerZonaUsuario = async (zonaId: number) => {
        try {
            if (usuarioId === undefined) {
                alert("favor seleccionar un usuario");
                return;
            }

            await axios.post(`${APIURL}/api/usuario/zona/remover`, { usuarioId, zonaId }, { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } });
            await obtenerZonasAsignadasUsuario(usuarioId);
            await obtenerZonasNoAsignadasUsuario(usuarioId);
        } catch (err) {

        }
    }

    return (
        <div>
            <div>
                <label>Usuario:</label>
                <select className="form-select" onChange={(e) => handleUsuarioSeleccionado(Number(e.target.value))}>
                    <option selected>Seleccione un usuario</option>
                    {usuarios.map(x => <option key={x.id} value={x.id}>{`${x.nombre} ${x.apellido}`}</option>)}
                </select>
            </div>

            <div className="container mt-5">
                <div className="row">
                    <div className="col">
                        <UsuarioZonaTable tipo="asignar" zonas={zonasNoAsignadas} accion={asignarZonaUsuario} />
                    </div>
                    <div className="col">
                        <UsuarioZonaTable tipo="remover" zonas={zonasAsignadas} accion={removerZonaUsuario} />
                    </div>
                </div>
            </div>
        </div>
    )
}