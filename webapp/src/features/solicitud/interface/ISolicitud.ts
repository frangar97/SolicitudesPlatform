export interface ISolicitud {
    id: number;
    descripcion: string;
    usuario: string;
    estadoSolicitud: string;
    tipoSolicitud: string;
    zona: string;
}