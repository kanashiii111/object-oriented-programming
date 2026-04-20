package org.oop.lab3.dto;

import javax.annotation.processing.Generated;
import org.oop.lab3.entities.Center;
import org.oop.lab3.entities.Player;
import org.oop.lab3.entities.PointGuard;
import org.springframework.stereotype.Component;

@Generated(
    value = "org.mapstruct.ap.MappingProcessor",
    date = "2026-04-21T01:38:39+0300",
    comments = "version: 1.5.5.Final, compiler: javac, environment: Java 26 (Oracle Corporation)"
)
@Component
public class PlayerMapperImpl implements PlayerMapper {

    @Override
    public PlayerDTO toDTO(Player player) {
        if ( player == null ) {
            return null;
        }

        PlayerDTO playerDTO = new PlayerDTO();

        playerDTO.id = player.getId();
        playerDTO.name = player.getName();
        if ( player.getHeight() != null ) {
            playerDTO.height = player.getHeight();
        }
        if ( player.getJerseyNumber() != null ) {
            playerDTO.jerseyNumber = player.getJerseyNumber();
        }
        if ( player.getType() != null ) {
            playerDTO.type = player.getType().name();
        }
        playerDTO.center = toDTO( player.getCenter() );
        playerDTO.pointGuard = toDTO( player.getPointGuard() );

        return playerDTO;
    }

    @Override
    public Player toEntity(PlayerDTO dto) {
        if ( dto == null ) {
            return null;
        }

        Player player = new Player();

        player.setId( dto.id );
        player.setCenter( toEntity( dto.center ) );
        player.setPointGuard( toEntity( dto.pointGuard ) );
        player.setName( dto.name );
        player.setHeight( dto.height );
        player.setJerseyNumber( dto.jerseyNumber );
        if ( dto.type != null ) {
            player.setType( Enum.valueOf( Player.Type.class, dto.type ) );
        }

        return player;
    }

    @Override
    public CenterDTO toDTO(Center center) {
        if ( center == null ) {
            return null;
        }

        CenterDTO centerDTO = new CenterDTO();

        centerDTO.id = center.getId();
        centerDTO.blocks = center.getBlocks();
        centerDTO.rebounds = center.getRebounds();
        centerDTO.blocksPerGame = center.getBlocksPerGame();
        centerDTO.reboundsPerGame = center.getReboundsPerGame();

        return centerDTO;
    }

    @Override
    public Center toEntity(CenterDTO dto) {
        if ( dto == null ) {
            return null;
        }

        Center center = new Center();

        center.setId( dto.id );
        center.setBlocks( dto.blocks );
        center.setRebounds( dto.rebounds );
        center.setBlocksPerGame( dto.blocksPerGame );
        center.setReboundsPerGame( dto.reboundsPerGame );

        return center;
    }

    @Override
    public PointGuardDTO toDTO(PointGuard pointGuard) {
        if ( pointGuard == null ) {
            return null;
        }

        PointGuardDTO pointGuardDTO = new PointGuardDTO();

        pointGuardDTO.id = pointGuard.getId();
        pointGuardDTO.assistsPerGame = pointGuard.getAssistsPerGame();
        pointGuardDTO.threePointPercentage = pointGuard.getThreePointPercentage();

        return pointGuardDTO;
    }

    @Override
    public PointGuard toEntity(PointGuardDTO dto) {
        if ( dto == null ) {
            return null;
        }

        PointGuard pointGuard = new PointGuard();

        if ( dto.id != null ) {
            pointGuard.setId( dto.id );
        }
        pointGuard.setAssistsPerGame( dto.assistsPerGame );
        pointGuard.setThreePointPercentage( dto.threePointPercentage );

        return pointGuard;
    }
}
