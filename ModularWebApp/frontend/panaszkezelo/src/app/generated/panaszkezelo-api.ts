//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v14.3.0.0 (NJsonSchema v11.2.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming



export class PanaszDto implements IPanaszDto {
    id?: string;
    cim?: string;
    leiras?: string;
    bejelentesDatuma?: Date;
    statusz?: string;

    constructor(data?: IPanaszDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.cim = _data["cim"];
            this.leiras = _data["leiras"];
            this.bejelentesDatuma = _data["bejelentesDatuma"] ? new Date(_data["bejelentesDatuma"].toString()) : <any>undefined;
            this.statusz = _data["statusz"];
        }
    }

    static fromJS(data: any): PanaszDto {
        data = typeof data === 'object' ? data : {};
        let result = new PanaszDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["cim"] = this.cim;
        data["leiras"] = this.leiras;
        data["bejelentesDatuma"] = this.bejelentesDatuma ? this.bejelentesDatuma.toISOString() : <any>undefined;
        data["statusz"] = this.statusz;
        return data;
    }
}

export interface IPanaszDto {
    id?: string;
    cim?: string;
    leiras?: string;
    bejelentesDatuma?: Date;
    statusz?: string;
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}