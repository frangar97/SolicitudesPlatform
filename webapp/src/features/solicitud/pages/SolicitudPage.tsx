import { useEffect, useState } from "react"
import { APIURL } from "../../../constants";
import { SolicitudTable } from "../components/SolicitudTable";
import { ISolicitud } from "../interface/ISolicitud";
import { solicitudApi } from "../../../helpers/client";
import { handleError } from "../../../helpers/handle_error";

export const SolicitudPage = () => {
    const [solicitudes, setSolicitudes] = useState<ISolicitud[]>([]);

    const obtenerSolicitudes = async () => {
        try {
            const request = await solicitudApi.get<ISolicitud[]>(`api/solicitud/aprobacion`);
            setSolicitudes(request.data);
        } catch (err) {
            handleError(err);
        }
    }

    const aprobarSolicitud = async (id: number) => {
        try {
            await solicitudApi.patch<ISolicitud[]>(`${APIURL}/api/solicitud/aprobar/${id}`);
            await obtenerSolicitudes();
        } catch (err) {
            handleError(err);
        }
    }

    const cancelarSolicitud = async (id: number) => {
        try {
            await solicitudApi.patch<ISolicitud[]>(`${APIURL}/api/solicitud/cancelar/${id}`);
            await obtenerSolicitudes();
        } catch (err) {
            handleError(err);
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