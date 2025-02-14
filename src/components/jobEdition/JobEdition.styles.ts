import { styled } from "@mui/system";
import { Box } from "@mui/material";

export const StyledContainer = styled(Box)({
    display: "flex",
    justifyContent: "space-between",
    alignItems: "flex-start",
    gap: "24px",
});

export const StyledEditorWrapper = styled(Box)({
    flex: 2,
});

export const StyledSidebarWrapper = styled(Box)({
    flex: 1,
    maxWidth: "400px",
});
