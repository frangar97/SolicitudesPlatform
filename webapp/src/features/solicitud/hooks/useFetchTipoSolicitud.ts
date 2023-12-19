import { useEffect, useState } from "react";
import { ITipoSolicitud } from "../interface/ITipoSolicitud";
import { solicitudApi } from "../../../helpers/client";

export const useFetchTipoSolicitud = () => {
    const [tiposSolicitud, setTiposSolicitud] = useState<ITipoSolicitud[]>([]);

    const obtenerTipoSolicitudes = async () => {
        try {
            const request = await solicitudApi.get<ITipoSolicitud[]>('/api/solicitud/tipos');
            setTiposSolicitud(request.data);
        } catch (err) {

        }
    }

    useEffect(() => {
        obtenerTipoSolicitudes();
    }, []);

    return {
        tiposSolicitud,
        setTiposSolicitud,
    }
}