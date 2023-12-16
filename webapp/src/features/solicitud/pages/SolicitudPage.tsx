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

    useEffect(() => {
        obtenerSolicitudes();
    }, []);

    return (
        <>
            <SolicitudTable solicitudes={solicitudes} estado="Pendiente" />
        </>
    )
}