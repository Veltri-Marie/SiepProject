import { Tooltip } from "@mui/material";
import avatarPicture from '../../../assets/siepLogo.png';
import { StyledAppBar, StyledToolbar, StyledTypography, StyledIconButton, StyledAvatar } from './LayoutAppBar.styles.ts';

const LayoutAppBar = () => (
    <StyledAppBar position="fixed">
        <StyledToolbar>
            <StyledTypography variant="h6">
                Isis - Gestion des métiers
            </StyledTypography>
            <Tooltip title="Profil" arrow>
                <StyledIconButton>
                    <StyledAvatar alt="User Avatar" src={avatarPicture} />
                </StyledIconButton>
            </Tooltip>
        </StyledToolbar>
    </StyledAppBar>
);

export default LayoutAppBar;