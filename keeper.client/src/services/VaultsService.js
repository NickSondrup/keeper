import { AppState } from "../AppState.js"
import { router } from "../router.js"
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
    AppState.userVaults.unshift(res.data)
  }

  async deleteVault(vaultId, profileId){
    const res = await api.delete(`api/vaults/${vaultId}`)
    logger.log('deleteVault', res)
    router.push({ name: 'Profile', params: { profileId: profileId}})
  }

  async addKeepToVault(data) {
    const res = await api.post('api/vaultkeeps', data)
    logger.log('addKeepToVault', res)
  }

  async removeVaultKeep(id) {
    const res = await api.delete(`api/vaultkeeps/${id}`)
    logger.log('removeVaultKeep', res)
    AppState.vaultKeeps = AppState.vaultKeeps.filter(k => k.vaultKeepId != id)
  }
}

export const vaultsService = new VaultsService()