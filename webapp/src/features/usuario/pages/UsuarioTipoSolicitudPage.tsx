import { useState } from "react";
import { useFetchUsuario } from "../hooks/useFetchUsuario";
import { ITipoSolicitud } from "../../solicitud/interface/ITipoSolicitud";
import { UsuarioTipoSolicitudTable } from "../components/UsuarioTipoSolicitudTable";
import { solicitudApi } from "../../../helpers/client";

export const UsuarioTipoSolicitudPage = () => {
    const { usuarios } = useFetchUsuario();
    const [usuarioId, setUsuarioId] = useState<number>();
    const [zonasAsignadas, setZonasAsignadas] = useState<ITipoSolicitud[]>([]);
    const [zonasNoAsignadas, setZonasNoAsignadas] = useState<ITipoSolicitud[]>([]);

    const obtenerTiposSolicitudAsignadasUsuario = async (usuarioId: number) => {
        try {
            const request = await solicitudApi.get<ITipoSolicitud[]>(`/api/usuario/tiposolicitud/asignadas/${usuarioId}`);
            setZonasAsignadas(request.data);
        } catch (err) {

        }
    }

    const obtenerTiposSolicitudNoAsignadasUsuario = async (usuarioId: number) => {
        try {
            const request = await solicitudApi.get<ITipoSolicitud[]>(`/api/usuario/tiposolicitud/noasignadas/${usuarioId}`);
            setZonasNoAsignadas(request.data);
        } catch (err) {

        }
    }

    const handleUsuarioSeleccionado = async (id: number) => {
        try {
            setUsuarioId(id);
            await obtenerTiposSolicitudAsignadasUsuario(id);
            await obtenerTiposSolicitudNoAsignadasUsuario(id);
        } catch (err) {

        }
    }

    const asignarTipoSolicitudUsuario = async (tipoSolicitudId: number) => {
        try {
            if (usuarioId === undefined) {
                alert("favor seleccionar un usuario");
                return;
            }

            await solicitudApi.post(`/api/usuario/tiposolicitud/asignar`, { usuarioId, tipoSolicitudId });
            await obtenerTiposSolicitudAsignadasUsuario(usuarioId);
            await obtenerTiposSolicitudNoAsignadasUsuario(usuarioId);
        } catch (err) {

        }
    }

    const removerTipoSolicitudUsuario = async (tipoSolicitudId: number) => {
        try {
            if (usuarioId === undefined) {
                alert("favor seleccionar un usuario");
                return;
            }

            await solicitudApi.post(`/api/usuario/tiposolicitud/remover`, { usuarioId, tipoSolicitudId });
            await obtenerTiposSolicitudAsignadasUsuario(usuarioId);
            await obtenerTiposSolicitudNoAsignadasUsuario(usuarioId);
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
                        <UsuarioTipoSolicitudTable tipo="asignar" tiposSolicitud={zonasNoAsignadas} accion={asignarTipoSolicitudUsuario} />
                    </div>
                    <div className="col">
                        <UsuarioTipoSolicitudTable tipo="remover" tiposSolicitud={zonasAsignadas} accion={removerTipoSolicitudUsuario} />
                    </div>
                </div>
            </div>
        </div>
    )
}