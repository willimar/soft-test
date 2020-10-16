using api.test.core.entities;
using api.test.core.interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace api.test.core.test.RepositoryTest
{
    /// <summary>
    /// O objetivo do teste unitário não é garantir o funcionamento do sistema, mas validar a mutabilidade de seu comportamento.
    /// </summary>
    public class RepositoryTest
    {
        private readonly Mock<IProvider<BaseEntity>> _provider;
        private readonly Repository<BaseEntity> _repository;

        public RepositoryTest()
        {
            this._provider = new Mock<IProvider<BaseEntity>>();
            this._repository = new Repository<BaseEntity>(this._provider.Object);

        }

        /// <summary>
        /// Garantir que se houver mudança no contrato possa ser percebido o impacto nas utilizações.
        /// </summary>
        [Fact]
        public void Repository_Interface_GetData()
        {
            var mock = new Mock<IRepository<BaseEntity>>();
            var id = Guid.NewGuid();
            var list = new List<BaseEntity>() { new BaseEntity() { Id = id } };
            mock.Setup(rep => rep.GetData(rec => rec.Id == id)).Returns(list);

            var repository = mock.Object;
            var result = repository.GetData(rec => rec.Id.Equals(id));

            mock.Verify(rep => rep.GetData(rec => rec.Id.Equals(id)), Times.Once);
            result.Should().NotBeNull();            
        }

        /// <summary>
        /// Validando o comportamento do constructor no controle. Deve sempre retornar ecxeption e com a mensagem específica. 
        /// Caso algo mude no constructor o teste deve ver.
        /// </summary>
        [Fact]
        public void Repository_Contructor_Exception()
        {
            Action action = () => new Repository<BaseEntity>(null);

            action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'provider')");
        }

        /// <summary>
        /// Validando comportamento para o método GetData onde sempre deve retornar valor.
        /// </summary>
        [Fact]
        public void Repository_GetData_Found()
        {
            var id = Guid.NewGuid();
            this._provider.Setup(prov => prov.DataSet).Returns(new List<BaseEntity>() { new BaseEntity() { Id = id } });

            var result = this._repository.GetData(entity => entity.Id.Equals(id));

            result.Should().NotBeNull();
            result.Should().Contain(x => x.Id == id);
        }

        /// <summary>
        /// Validando comportamento para o método GetData onde sempre deve retornar vazio.
        /// </summary>
        [Fact]
        public void Repository_GetData_NotFound()
        {
            var id = Guid.NewGuid();
            this._provider.Setup(prov => prov.DataSet).Returns(new List<BaseEntity>() { new BaseEntity() { Id = id } });

            var result = this._repository.GetData(entity => entity.Id.Equals(Guid.NewGuid()));

            result.Should().BeEmpty();
        }
    }
}
