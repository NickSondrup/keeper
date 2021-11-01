import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService{

  async getVault(vaultId) {
    AppState.vault = {}
    const res = await api.get(`api/vaults/${vaultId}`)
    logger.log(res)
    AppState.vault = res.data
  }

  async createVault(vaultData) {
    const res = await api.post('api/vaults', vaultData)
    logger.log('createVault', res)
    AppState.vaults.unshift(res.data)
  }
}

export const vaultsService = new VaultsService()