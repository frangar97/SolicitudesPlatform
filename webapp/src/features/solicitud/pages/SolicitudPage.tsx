import { useEffect, useState } from "react"
import axios from "axios";
import { APIURL } from "../../../constants";
import { SolicitudTable } from "../components/SolicitudTable";
import { ISolicitud } from "../interface/ISolicitud";

export const SolicitudPage = () => {
    const [solicitudes, setSolicitudes] = useState<ISolicitud[]>([]);

    const obtenerSolicitudes = async () => {
        try {
            const request = await axios.get<ISolicitud[]>(`${APIURL}/api/solicitud/aprobacion`, { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } });
            setSolicitudes(request.data);
        } catch (err) {

        }
    }

    const aprobarSolicitud = async (id: number) => {
        try {
            await axios.put<ISolicitud[]>(`${APIURL}/api/solicitud/aprobar/${id}`, { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } });
            await obtenerSolicitudes();
        } catch (err) {

        }
    }

    const cancelarSolicitud = async (id: number) => {
        try {
            await axios.put<ISolicitud[]>(`${APIURL}/api/solicitud/cancelar/${id}`, { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } });
            await obtenerSolicitudes();
        } catch (err) {

        }
    }

    useEffect(() => {
        obtenerSolicitudes();
    }, []);

    return (
        <>
            <SolicitudTable solicitudes={solicitudes} aprobarSolicitud={aprobarSolicitud} cancelarSolicitud={cancelarSolicitud} estado="Pendiente" />
        </>
    )
}